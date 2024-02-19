using System;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.ChangeTracking;




Console.WriteLine($"Using {ProjectConstansts.DataBaseProvider} database provider");
//QueryingCategories();
//FiltredIncludes();
// QueryingProducts();

// if (AddProduct(categoryId: 6,
//  productName: "Bob's Burgers", price: 500M))
// {
//     Console.WriteLine("Add product successful.");
// }
// ListProducts();


// if (IncreaseProductPrice(
//  productNameStartsWith: "Bob", amount: 20M))
// {
//     Console.WriteLine("Update product price successful.");
// }
// ListProducts();

int deleted = DeleteProducts(productNameStartsWith: "Bob");
Console.WriteLine($"{deleted} product(s) were deleted.");

static void QueryingCategories()
{
    using (Northwind db = new())
    {
        // ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        // loggerFactory.AddProvider(new ConsoleLoggerProvider());
        Console.WriteLine("Categories and how many products they have:");

        IQueryable<Category>? categories;           //db.Categories; //?.Include(c => c.Products);

        db.ChangeTracker.LazyLoadingEnabled = false;

        Console.Write("Enable eager loading? (Y/N): ");
        bool eagerloading = (Console.ReadKey().Key == ConsoleKey.Y);
        bool explicitloading = false;
        Console.WriteLine();

        if (eagerloading)
        {
            categories = db.Categories?.Include(c => c.Products);
        }
        else
        {
            categories = db.Categories;
            Console.Write("Enable explicit loading? (Y/N): ");
            explicitloading = (Console.ReadKey().Key == ConsoleKey.Y);
            Console.WriteLine();
        }

        foreach (var c in categories)
        {
            if (explicitloading)
            {
                Console.Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.Y)
                {
                    CollectionEntry<Category, Product> products =
                    db.Entry(c).Collection(c2 => c2.Products);
                    if (!products.IsLoaded) products.Load();
                }
            }
            Console.WriteLine(($"{c.CategoryName} has {c.Products.Count} products."));
        }

    }
}


static bool AddProduct(int categoryId, string productName, decimal? price)
{
    using (Northwind db = new())
    {
        Product p = new()
        {
            CategoryId = categoryId,
            ProductName = productName,
            Cost = price
        };
        
        db.Products.Add(p);
     
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}



static bool IncreaseProductPrice(string productNameStartsWith, decimal amount)
{
    using (Northwind db = new())
    {
        Product updateProduct = db.Products.First(
         p => p.ProductName.StartsWith(productNameStartsWith));
        updateProduct.Cost += amount;
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}

static int DeleteProducts(string productNameStartsWith)
{
    using (Northwind db = new())
    {
        IQueryable<Product>? products = db.Products?.Where(
        p => p.ProductName.StartsWith(productNameStartsWith));
        if (products is null)
        {
            Console.WriteLine("No products found to delete.");
            return 0;
        }
        else
        {
            db.Products.RemoveRange(products);
        }
        int affected = db.SaveChanges();
        return affected;
    }
}

static void ListProducts()
{
    using (Northwind db = new())
    {
        Console.WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
        "Id", "Product Name", "Cost", "Stock", "Disc.");
        foreach (Product p in db.Products
        .OrderByDescending(product => product.Cost))
        {
            Console.WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
            p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
        }
    }
}

static void FiltredIncludes()
{
    using (Northwind db = new())
    {
        Console.Write("Enter a minimum for units in stock: ");
        string unitStock = Console.ReadLine() ?? "10";
        int stock = int.Parse(unitStock);

        IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));

        if (categories is null)
        {
            Console.WriteLine("NO found");
            return;
        }
        Console.WriteLine($"ToQueryString: {categories.ToQueryString()}");
        foreach (Category c in categories)
        {
            Console.WriteLine($"{c.CategoryName} has {c.Products.Count}  with a minimum of {stock} units in stock.");

            foreach (Product p in c.Products)
            {
                Console.WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
            }
        }

    }

}

static void QueryingProducts()
{
    using (Northwind db = new())
    {
        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        Console.WriteLine("Products that cost more than a price, highest at top.");
        string? input;
        decimal price;

        do
        {
            Console.WriteLine("Enter a product price");
            input = Console.ReadLine();
        } while (!decimal.TryParse(input, out price));

        IQueryable<Product> products = db.Products?.Where(product => product.Cost > price).OrderByDescending(product => product.Cost);

        if (products is null)
        {
            Console.WriteLine("NO FOUND");
            return;
        }

        foreach (Product p in products)
        {
            Console.WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.", p.ProductId, p.ProductName, p.Cost, p.Stock);
        }
    }
}

static void QueryingWithLike()
{
    using (Northwind db = new())
    {
        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        Console.Write("Enter part of a product name: ");
        string? input = Console.ReadLine();
        IQueryable<Product>? products = db.Products?
        .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
        if (products is null)
        {
            Console.WriteLine("No products found.");
            return;
        }
        foreach (Product p in products)
        {
            Console.WriteLine("{0} has {1} units in stock. Discontinued? {2}",
        p.ProductName, p.Stock, p.Discontinued);
        }
    }
}