using GalleryList.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// ������ ����������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//������ �������� � ����� ������ � ��� �������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

//��������� �������� ��������� �����

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

// ��������� ������
//app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

app.Run();
