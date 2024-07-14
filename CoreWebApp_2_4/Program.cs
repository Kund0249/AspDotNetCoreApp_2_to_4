using CoreWebApp_2_4.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add your Services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("data source=DESKTOP-G3RV5V6;database=BMSDB;TrustServerCertificate=True;trusted_connection=true");
});

var app = builder.Build();

//Add your middlewares
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", 
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
