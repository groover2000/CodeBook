using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
namespace Northwind.Web.Pages;
using Packt.Shared;
public class SuppliersModel : PageModel
{
    private NorthwindContext? db;

    public IOrderedQueryable<Supplier> Suppliers { get; set; }

    public SuppliersModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Suppliers";
        Suppliers = db.Suppliers
        .OrderBy(c => c.Country)
        .ThenBy(c => c.CompanyName);
    }
}