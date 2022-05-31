using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Add the JsonFileProductService to the serviceContainer
builder.Services.AddTransient<JsonFileProductService>();
// Add the Controller Service to the service Continer
builder.Services.AddControllers();
// Add the blazor service to the service container
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// create an endpoint for all the products to be returned in JSON Format (Create a Mini API)
/*app.MapGet("/products", (context) =>
{
    var products = app.Services.GetService<JsonFileProductService>().GetProducts();
    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);

    return context.Response.WriteAsync(json);
});*/

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add the controller to the mapper,
app.MapControllers();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapBlazorHub();

app.Run();
