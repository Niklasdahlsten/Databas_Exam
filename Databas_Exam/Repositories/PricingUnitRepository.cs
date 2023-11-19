using Databas_Exam.Contexts;
using Databas_Exam.Entities;

namespace Databas_Exam.Repositories;

internal class PricingUnitRepository : Repo<PricingUnitEntity>
{
    public PricingUnitRepository(DataContext context) : base(context)
    {
    }
}
