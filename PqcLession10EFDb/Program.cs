using Microsoft.EntityFrameworkCore;
using PqcLession10EFDb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình kết nối cơ sở dữ liệu DbContext
var pqcConnectionString = builder.Configuration.GetConnectionString("PqcLesson10EfConnectionString");
builder.Services.AddDbContext<Pqck24cnt1lession10EfdbContext>(x => x.UseSqlServer(pqcConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
