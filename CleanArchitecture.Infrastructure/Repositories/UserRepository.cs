using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class UserRepository(MainContext context) : GenericRepository<User, Guid>(context), IUserRepository
{
	public Task<User?> GetByIdWithIncludes(Guid userId)
	{
		return GetEntityQuery()
			.Include(u => u.Gender)
			.FirstOrDefaultAsync(u => u.Id.Equals(userId));
	}
}
