using FoodBee.Models;
using FoodBee.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodBee
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton<IFoodBeeService<MapLayer>, MapLayerService<MapLayer>>();
            builder.Services.AddSingleton<IFoodBeeService<Filter>, FilterService<Filter>>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IFoodBeeService<Vendor>, VendorService<Vendor>>();
            builder.Services.AddScoped<IFoodBeeService<Product>, ProductService<Product>>();


            var host = builder.Build();

            var vendorService = host.Services.GetRequiredService<IFoodBeeService<Vendor>>();
            await vendorService.InitializeAsync();

            var productService = host.Services.GetRequiredService<IFoodBeeService<Product>>();
            await productService.InitializeAsync();

            await host.RunAsync();
        }
    }
}
