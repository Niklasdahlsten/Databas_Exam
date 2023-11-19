using System.ComponentModel.DataAnnotations;

namespace Databas_Exam.Entities;

public class ProductCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

}
