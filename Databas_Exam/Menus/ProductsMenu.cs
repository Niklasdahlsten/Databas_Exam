using Databas_Exam.Models;
using Databas_Exam.Services;

namespace Databas_Exam.Menus;

internal class ProductsMenu
{

    private readonly ProductService _productService;

    public ProductsMenu(ProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    public async Task ManageProducts()
    {
        Console.Clear();

        Console.WriteLine("Hantera produkter");
        Console.WriteLine("1. Visa alla produkter");
        Console.WriteLine("2. Lägg till produkt");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;

            case "2":
                await CreateAsync();
                break;
        }
    }


    public async Task CreateAsync()
    {
        var form = new ProductRegistrationForm();

        Console.Clear();
        Console.Write("Produktens namn: ");
        form.ProductName = Console.ReadLine()!;

        Console.Write("Produktbeskrivning: ");
        form.ProductDescription = Console.ReadLine()!;

        Console.Write("Produktens pris (SEK): ");
        form.ProductPrice = decimal.Parse(Console.ReadLine()!);

        Console.Write("Prisgrupp för produkt (St/packet/timme) (SEK): ");
        form.PricingUnit = Console.ReadLine()!;

        Console.Write("Produktens kategori: ");
        form.ProductCategory = Console.ReadLine()!;


        var result = await _productService.CreateProductAsync(form);
        if (result)
            Console.WriteLine("Registrering av produkt lyckades.");
        else
            Console.WriteLine("Kunde ej registrera produkten. ");
    }

    public async Task ListAllAsync()
    {
        Console.Clear();

        var products = await _productService.GetAllAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductName} {product.ProductCategory}");
            Console.WriteLine($"{product.ProductPrice} {product.PricingUnit.Unit}");
            Console.WriteLine("");

        }
        Console.ReadKey();
    }
}
