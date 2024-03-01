namespace Northwind.Web;
using Packt.Shared;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddNorthwindContext();
    }
    public void Configure(
    IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }
        
        app.UseRouting(); // начало маршрутизации конечной точки
        app.UseHttpsRedirection();

        app.UseDefaultFiles(); // index.html, default.html и т.п.
        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();

            endpoints.MapGet("/hello", () => "Hello World!");
        });
    }
}