namespace Databas_Exam.Menus;

internal class MainMenu
{

    private readonly CustomerMenu _customerMenu;
    private readonly ProductsMenu _productMenu;

    public MainMenu(CustomerMenu customerMenu, ProductsMenu productMenu)
    {
        _customerMenu = customerMenu;
        _productMenu = productMenu;
    }
    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Hantera kunder");
            Console.WriteLine("2. Hantera Produkter");
            Console.Write("Välj ett alternativ, 1-2: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _customerMenu.ManageCustomers();
                    break;

                case "2":
                    await _productMenu.ManageProducts();
                    break;

            }
        }
        while (true);
    }
}
