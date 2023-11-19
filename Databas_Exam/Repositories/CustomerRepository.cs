using Databas_Exam.Contexts;
using Databas_Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Databas_Exam.Repositories;

internal class CustomerRepository : Repo<CustomerEntity>
{
    private readonly DataContext _context;
    public CustomerRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.Include(x => x.Address).ToListAsync();
    }
}
