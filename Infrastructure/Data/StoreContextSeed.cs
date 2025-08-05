using System.Text.Json;
using System.Text.Json.Serialization;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Products.Any())
        {
            string productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/Products.json");
            if (!string.IsNullOrEmpty(productsData))
            {
                List<Product> products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
                await context.SaveChangesAsync();   
            }
            return;
        }

        return;
    }
}