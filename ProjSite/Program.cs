using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc.Routing;
using MyApp.Namespace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "Home.Index",
    pattern: "{controller=Home}/{action=Index}")
    .WithStaticAssets();

app.MapControllerRoute (
    name: "Home.Sobre",
    pattern: "Sobre",
    defaults: new {controller = "Home", action = "Sobre"}
);


app.Run();
