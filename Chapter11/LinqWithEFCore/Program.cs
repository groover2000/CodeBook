

using Microsoft.EntityFrameworkCore;
using Pact.Shared;


AggregateProducts();
// GroupJoinCategoriesAndProducts();
// JoinCategoriesAndProducts();
// FilterAndSort();

static void FilterAndSort()
{

    using (Northwind db = new())
    {
        DbSet<Product> allProducts = db.Products;
        int[] some = [1, 2, 3];
        var filteredProducts = allProducts.Where(product => product.UnitPrice < 10m);
        var sortedAndFilteredProducts = filteredProducts.OrderByDescending(product => product.UnitPrice);

        var projectedProducts = sortedAndFilteredProducts.Select(product => new
        {
            product.ProductId,
            product.ProductName,
            product.UnitPrice
        });

        Console.WriteLine("Products that cost less than $10:");
        foreach (var p in projectedProducts)
        {
            Console.WriteLine("{0}: {1} costs {2:$#,##0.00}",
            p.ProductId, p.ProductName, p.UnitPrice);
        }
        Console.WriteLine();
    }
}

static void JoinCategoriesAndProducts()
{
    using (Northwind db = new())
    {
        var queryJoin = db.Categories.Join(db.Products, category => category.CategoryId, product => product.ProductId, (c, p) =>
        new { c.CategoryName, p.ProductName, p.ProductId });

        foreach (var item in queryJoin)
        {
            Console.WriteLine("{0}: {1} is in {2}.",
            arg0: item.ProductId,
            arg1: item.ProductName,
            arg2: item.CategoryName);
        }
    }
}

static void GroupJoinCategoriesAndProducts()
{
    using (Northwind db = new())
    {
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(db.Products, category => category.CategoryId, products => products.CategoryId, (c, matchingProducts) =>
        new { c.CategoryName, Products = matchingProducts.OrderBy(p => p.ProductName) });
        foreach (var category in queryGroup)
        {
            Console.WriteLine("{0} has {1} products.",
            arg0: category.CategoryName,
            arg1: category.Products.Count());
            foreach (var product in category.Products)
            {
                Console.WriteLine($" {product.ProductName}");
            }
        }
    }
}

static void AggregateProducts()
{
    using (Northwind db = new())
    {
        Console.WriteLine("{0,-25} {1,10}",
        arg0: "Product count:",
        arg1: db.Products.Count());
        Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
        arg0: "Highest product price:",
        arg1: db.Products.Max(p => p.UnitPrice));
        Console.WriteLine("{0,-25} {1,10:N0}",
        arg0: "Sum of units in stock:",
        arg1: db.Products.Sum(p => p.UnitsInStock));
        Console.WriteLine("{0,-25} {1,10:N0}",
        arg0: "Sum of units on order:",
        arg1: db.Products.Sum(p => p.UnitsOnOrder));
        Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
        arg0: "Average unit price:",
        arg1: db.Products.Average(p => p.UnitPrice));
        Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
        arg0: "Value of units in stock:",
        arg1: db.Products
        .Sum(p => p.UnitPrice * p.UnitsInStock));
    }
}