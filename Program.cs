using LocalBrands.Data;
using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using LocalBrands.Services.Implementation;
using LocalBrands.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDB>();
builder.Services.AddDbContext<ApplicationDB>(optionbuilder =>
{
    optionbuilder.UseSqlServer(builder.Configuration.GetConnectionString("conString"));
});
// custom services for Repositories :
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<ReviewRepo>();
builder.Services.AddScoped<BrandRepo>();

builder.Services.AddScoped<IProductRepo>(sp=>sp.GetRequiredService<ProductRepo>());
builder.Services.AddScoped<IRepository<Product>>(sp=>sp.GetRequiredService<ProductRepo>());
builder.Services.AddScoped<IReviewRepo>(sp => sp.GetRequiredService<ReviewRepo>());
builder.Services.AddScoped<IRepository<Review>>(sp => sp.GetRequiredService<ReviewRepo>());
builder.Services.AddScoped<IBrandRepo>(sp => sp.GetRequiredService<BrandRepo>());
builder.Services.AddScoped<IRepository<Brand>>(sp => sp.GetRequiredService<BrandRepo>());
builder.Services.AddScoped<IHomeService, HomeService>();





//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
