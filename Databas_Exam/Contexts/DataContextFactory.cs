using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Databas_Exam.Contexts;

internal class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skoluppgifter\Databas\Database_exam\DatabaseAssignment\Databas_Exam\Contexts\Finalexam_database.mdf;Integrated Security=True;Connect Timeout=30");
        return new DataContext(optionsBuilder.Options);

    }

}
