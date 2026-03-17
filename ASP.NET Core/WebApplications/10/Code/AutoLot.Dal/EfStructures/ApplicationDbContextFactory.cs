// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = "Server=(localdb)\\mssqllocaldb;Database=AutoLot_Test;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connectionString);
        //var connectionString = @"server=(localdb)\ProjectModels;Database=AutoLot_Hol;Trusted_Connection=True;";
        //var connectionString = @"server=.,5433;Database=AutoLot_Hol;User Id=sa;Password=P@ssw0rd;Encrypt=false;";
        //optionsBuilder.UseSqlServer(connectionString);
        Console.WriteLine(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
