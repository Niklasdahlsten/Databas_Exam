using Databas_Exam.Contexts;
using Databas_Exam.Menus;
using Databas_Exam.Repositories;
using Databas_Exam.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Databas_Exam
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skoluppgifter\Databas\Database_exam\DatabaseAssignment\Databas_Exam\Contexts\Finalexam_database.mdf;Integrated Security=True;Connect Timeout=30"));

            services.AddScoped<AddressRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<PricingUnitRepository>();
            services.AddScoped<ProductCategoryRepository>();
            services.AddScoped<ProductRepository>();

            services.AddScoped<CustomerService>();
            services.AddScoped<ProductService>();
            services.AddScoped<CustomerMenu>();
            services.AddScoped<ProductsMenu>();
            services.AddScoped <MainMenu>();

            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            var customerMenu = sp.GetRequiredService<CustomerMenu>();

            await mainMenu.StartAsync();
        }
    }
}