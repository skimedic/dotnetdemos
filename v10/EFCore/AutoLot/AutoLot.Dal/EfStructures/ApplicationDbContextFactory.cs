// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot_Hol;Integrated Security=true;";
        //var connectionString = @"server=(localdb)\ProjectModels;Database=AutoLot_Hol;Trusted_Connection=True;";
        //var connectionString = @"server=.,5433;Database=AutoLot_Hol;User Id=sa;Password=P@ssw0rd;Encrypt=false;";
        optionsBuilder.UseSqlServer(connectionString);
        //This is for teaching purposes only, you should not use this in production code.
        Console.WriteLine(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}