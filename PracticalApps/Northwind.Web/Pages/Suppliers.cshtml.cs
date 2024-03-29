using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
namespace Northwind.Web.Pages;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc; // [BindProperty], IactionResult

public class SuppliersModel : PageModel
{
    private readonly NorthwindContext? db;
    [BindProperty]
    public Supplier? Supplier { get; set; }
    public IQueryable<Supplier> Suppliers { get; set; }

    public SuppliersModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Suppliers";
        Suppliers = db.Suppliers
        .OrderBy(c => c.Country)
        .ThenBy(c => c.CompanyName)
        .Select(db => new Supplier { CompanyName = db.CompanyName, Country = db.Country, Phone = db.Phone });
    }
    public IActionResult OnPost()
    {
        if ((Supplier is not null) && ModelState.IsValid)
        {
            db.Suppliers.Add(Supplier);
            db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        else
        {
            return Page(); // возвращает исходную страницу
        }
    }
}