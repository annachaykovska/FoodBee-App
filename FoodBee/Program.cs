using FoodBee.Models;
using FoodBee.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodBee
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<IFoodBeeService<MapLayer>, MapLayerService<MapLayer>>();
            builder.Services.AddScoped<IFoodBeeService<Filter>, FilterService<Filter>>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IFoodBeeService<Vendor>, VendorService<Vendor>>();
            builder.Services.AddScoped<IFoodBeeService<Product>, ProductService<Product>>();
            builder.Services.AddScoped<ISearchService, SearchService>();

            var host = builder.Build();

            var vendorService = host.Services.GetRequiredService<IFoodBeeService<Vendor>>();
            await vendorService.InitializeAsync();

            var productService = host.Services.GetRequiredService<IFoodBeeService<Product>>();
            await productService.InitializeAsync();

            await host.RunAsync();
        }
    }
}
