using Databas_Exam.Contexts;
using Databas_Exam.Entities;

namespace Databas_Exam.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
