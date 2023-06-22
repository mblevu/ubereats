using Microsoft.EntityFrameworkCore;
using UberEats.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddControllersWithViews();

// Retrieve the connection string from the configuration
var connectionString = builder.Configuration.GetConnectionString("UberEatsContext");

// Check if the connection string is null and handle it accordingly
if (connectionString != null)
{
    builder.Services.AddDbContext<UberEatsContext>(options =>
        options.UseSqlServer(connectionString));
}

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

// map route for Admin area
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

// map default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
