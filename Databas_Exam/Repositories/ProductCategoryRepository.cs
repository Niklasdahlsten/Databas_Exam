using Databas_Exam.Contexts;
using Databas_Exam.Entities;

namespace Databas_Exam.Repositories;

internal class ProductCategoryRepository : Repo<ProductCategoryEntity>
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}
