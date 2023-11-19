using Databas_Exam.Models;
using Databas_Exam.Services;

namespace Databas_Exam.Menus;

internal class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();

        Console.WriteLine("Hantera kunder");
        Console.WriteLine("1. Visa alla kunder");
        Console.WriteLine("2. Lägg till kund");

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
        var form = new CustomerRegistrationForm();

        Console.Clear();
        Console.Write("Förnamn: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write("Efternamn: ");
        form.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;

        Console.Write("Adress: ");
        form.StreetName = Console.ReadLine()!;

        Console.Write("Postnummer: ");
        form.PostalCode = Console.ReadLine()!;

        Console.Write("Stad: ");
        form.City = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(form);
        if (result)
            Console.WriteLine("Registrering av kund lyckades.");
        else
            Console.WriteLine("Kunde ej registrera kund. ");
    }

    public async Task ListAllAsync()
    {
        Console.Clear();

        var customers = await _customerService.GetAllAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}. ");
            Console.WriteLine("");

        }
        Console.ReadKey();
    }
}
