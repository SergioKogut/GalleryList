using GalleryList.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// строка підключення
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//додаємо контекст в якості сервісу в наш додаток
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

//додавання підтримки статичних файлів

if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"Uploaded")))
{
    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"Uploaded"));
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Uploaded")),
    RequestPath = "/Uploaded"
}
    );

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

// отримання данних
//app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

app.Run();
