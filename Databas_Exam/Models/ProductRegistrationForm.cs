using System.Data.SqlTypes;

namespace Databas_Exam.Models;

internal class ProductRegistrationForm
{
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public string PricingUnit { get; set; } = null!;

    public int PricingUnitId { get; set; } 
    public string ProductCategory { get; set; } = null!;
}
