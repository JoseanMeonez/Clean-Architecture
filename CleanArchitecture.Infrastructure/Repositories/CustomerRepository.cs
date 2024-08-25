using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository(MainContext context) : GenericRepository<Customer, int>(context), ICustomerRepository
{
	public Task<Customer?> GetByIdWithIncludes(int customerId)
	{
		return GetEntityQuery()
			.Include(c => c.Emails)
			.Include(c => c.Gender)
			.Include(c => c.IdentificationType)
			.Include(c => c.PhoneNumbers)
			.Include(c => c.Prospect)
			.Include(c => c.References)
			.FirstOrDefaultAsync(ea => ea.Id == customerId);
	}
}
