using Microsoft.EntityFrameworkCore;
using WebCRUDMVCSQL.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(
        "Data Source=TQR224240;Initial Catalog=CRUD_MVC_SQL_CANAL_DEV;Integrated Security=False;User ID=tds;Password=tds123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ? IMPORTANTE

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();