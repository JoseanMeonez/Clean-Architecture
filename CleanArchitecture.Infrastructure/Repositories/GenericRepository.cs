using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class GenericRepository<T, TId> : IGenericRepository<T, TId>
		where T : BaseEntity<TId>
{
	private readonly MainContext _context;
	private readonly DbSet<T> _entity;

	/// <summary>
	/// Initializes a new instance of the <see cref="GenericRepository"/> class.
	/// </summary>
	/// <param name="context">The database context.</param>
	public GenericRepository(MainContext context)
	{
		_context = context;
		_entity = _context.Set<T>();
	}

	/// <inheritdoc />
	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _entity.OrderByDescending(e => e.Id).ToListAsync();
	}

	/// <inheritdoc />
	public async Task<T?> GetByIdAsync(TId id)
	{
		return await _entity.FindAsync(id);
	}

	/// <inheritdoc />
	public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
	{
		return _entity.AnyAsync(predicate);
	}

	/// <inheritdoc />
	public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
	{
		IQueryable<T> query = _entity;

		if (filter != null)
		{
			query = query.Where(filter);
		}

		return query;
	}

	/// <inheritdoc />
	public async Task<T> InsertAsync(T entity)
	{
		EntityEntry<T> insertedValue = await _entity.AddAsync(entity);

		return insertedValue.Entity;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entities)
	{
		await _entity.AddRangeAsync(entities);

		return entities;
	}

	/// <inheritdoc />
	public void Update(T entity)
	{
		_entity.Update(entity);
	}

	/// <inheritdoc />
	public void UpdateRange(IEnumerable<T> entities)
	{
		_entity.UpdateRange(entities);
	}

	/// <inheritdoc />
	public async Task<bool> DeleteAsync(TId id)
	{
		T? entity = await GetByIdAsync(id);

		if (entity == null)
		{
			return false;
		}

		_entity.Remove(entity);

		return true;
	}

	/// <inheritdoc />
	public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return await _context.SaveChangesAsync(cancellationToken);
	}
}
