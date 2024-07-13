var builder = WebApplication.CreateBuilder(args);
//Add your Services
builder.Services.AddControllersWithViews();

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
