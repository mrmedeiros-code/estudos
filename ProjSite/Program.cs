using Microsoft.AspNetCore.Mvc.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "Home.Index",
    pattern: "",
    defaults : new { controller = "Home", action = "Index" }) 
    .WithStaticAssets();

app.MapControllerRoute(
    name : "Home.Contato",
    pattern : "contato",
    defaults : new { controller = "Home", action = "Contato" });

app.Run();
