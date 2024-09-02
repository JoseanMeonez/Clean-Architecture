using Domain.Entities;

namespace Infrastructure.Interfaces;

internal interface IUserRepository : IGenericRepository<User, Guid>
{
	/// <summary>
	/// Gets the user with the specified identifier and its related references eagerly loaded.
	/// </summary>
	/// <param name="userId">The unique identifier of the user.</param>
	/// <returns>The user entity with its related references loaded, or null if not found.</returns>
	Task<User?> GetByIdWithIncludes(Guid userId);
}
