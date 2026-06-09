using Microsoft.EntityFrameworkCore;
using WebCRUDMVCSQL.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>
(
    options => options.UseSqlServer(
        "Data Source=TQR224240;Initial Catalog=CRUD_MVC_SQL_CANAL_DEV;Integrated Security=False;User ID=tds;Password=tds123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
);

var app = builder.Build();

var cultura = new CultureInfo("pt-BR");

CultureInfo.DefaultThreadCurrentCulture = cultura;
CultureInfo.DefaultThreadCurrentUICulture = cultura;

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultura),
    SupportedCultures = new[] { cultura },
    SupportedUICultures = new[] { cultura }
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();