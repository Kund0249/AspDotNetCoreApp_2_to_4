var builder = WebApplication.CreateBuilder(args);
//Add your Services
builder.Services.AddMvc();

var app = builder.Build();

//Add your middlewares
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", 
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
