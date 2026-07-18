// Copyright Information
// ==================================
// EFCoreExamples - 01_PerformanceEfCore - TestEfCore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

using System;
using System.Linq;
using PerformanceEfCore;
using PerformanceEfCore.Entities;
using Microsoft.EntityFrameworkCore;
using PerformanceEfCore.Context;

namespace PerformanceEfCore;

public static class TestEfCore
{
    public static void GetAllCustomers()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        db.Customers.ToList();
    }
    public static void GetAllCustomersAsNoTracking()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        db.Customers.AsNoTrackingWithIdentityResolution().ToList();
    }

    public static void GetAllCustomersQueryType()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        db.Database.SqlQueryRaw<CustomerQuery>("Select * from Sales.Customer").ToList();
    }
    public static void RunComplexQuery()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        var l = db.Products
            .Include(x => x.TransactionHistories)
            //.Include(x => x.ProductSubcategory)
            .Include(x => x.ProductSubcategory).ThenInclude(x=>x.ProductCategory)
            .Include(x => x.ProductReviews)
            .Take(100)
            .Select(x => new ModelForTesting()
            {
                ProductId = x.ProductId,
                Class = x.Class,
                ModifiedDate = x.TransactionHistories.Select(th => th.ModifiedDate).FirstOrDefault(),
                CategoryName = x.ProductSubcategory.ProductCategory.Name,
                Email = x.ProductReviews.Select(pr => pr.EmailAddress).FirstOrDefault()
            })
            .ToList();
    }
    public static void RunNonSplitQuery()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        var l = db.Products
            .Include(x => x.TransactionHistories)
            .Include(x => x.ProductSubcategory).ThenInclude(x=>x.ProductCategory)
            //.Include(x => x.ProductSubcategory).ThenInclude(x=>x.Product)
            .Include(x => x.ProductReviews)
            .Select(x => new ModelForTesting()
            {
                ProductId = x.ProductId,
                Class = x.Class,
                ModifiedDate = x.TransactionHistories.Select(th => th.ModifiedDate).FirstOrDefault(),
                CategoryName = x.ProductSubcategory.ProductCategory.Name,
                Email = x.ProductReviews.Select(pr => pr.EmailAddress).FirstOrDefault()
            })
            .Take(100).ToList();
    }
    public static void RunSplitQuery()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        var l = db.Products.AsSplitQuery()
            .Include(x => x.TransactionHistories)
            .Include(x => x.ProductSubcategory).ThenInclude(x=>x.ProductCategory)
            .Include(x => x.ProductReviews)
            .Select(x => new ModelForTesting()
            {
                ProductId = x.ProductId,
                Class = x.Class,
                ModifiedDate = x.TransactionHistories.Select(th => th.ModifiedDate).FirstOrDefault(),
                CategoryName = x.ProductSubcategory.ProductCategory.Name,
                Email = x.ProductReviews.Select(pr => pr.EmailAddress).FirstOrDefault()
            })
            .Take(100).ToList();
    }

    public static void AddRecordsAndSave()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        for (int i = 0; i < 1000; i++)
        {
            db.ProductCategories.Add(new ProductCategory { Name = $"Test {Guid.NewGuid()}",ModifiedDate = DateTime.Now });
        }
        db.SaveChanges();
    }

    public static void AddRecordsAndSaveNoBatching()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        for (int i = 0; i < 1000; i++)
        {
            db.ProductCategories.Add(new ProductCategory { Name = $"Test {Guid.NewGuid()}",ModifiedDate = DateTime.Now });
        }
        db.SaveChanges();
    }

    public static void ResetAndWarmUp()
    {
        var builder = new DbContextOptionsBuilder<AW2019Context>();
        var connectionString = @"server=.\dev2019;Database=Adventureworks2019;Trusted_Connection=True;Encrypt=false;";
        builder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));

        using var db = new AW2019Context(builder.Options);
        db.Database.ExecuteSqlRaw(@"DELETE FROM Production.ProductCategory WHERE Name LIKE 'Test %'");
        db.Database.ExecuteSqlRaw(@"DBCC CHECKIDENT ('Production.ProductCategory', RESEED)");
        db.Customers.FirstOrDefault();
    }
}