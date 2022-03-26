using FoodBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FoodBee.Services
{
    /// <summary>
    /// This servive handles data access for FoodBee products. On application startup is asyncronously loads the products 
    /// from an HTTP request to `wwwroot/data/products.json` which contains a list of pre-generated products and is cached for 
    /// easier access throughout the web page's lifetime.
    /// The service also handles the abilioty for a user to bookmark/save a product, which are denoted as "Active" products (by name)
    /// since this class implements the generic IFoodBeeService interface.
    /// </summary>
    /// <typeparam name="T">FoodBee.Models.Product</typeparam>
    public class ProductService<T> : IFoodBeeService<Product>
    {
        private List<Product> _allProducts;
        private List<string> _savedProducts;
        private HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
            _savedProducts = new List<string>();
        }

        public async Task InitializeAsync()
        {
            Console.WriteLine("Initializeing FoodBee products");
            Product[] products = await _http.GetFromJsonAsync<Product[]>("data/products.json");
            _allProducts = products.ToList();
        }

        public List<Product> GetAll() => _allProducts != null ? _allProducts : new List<Product>();

        public void ClearActive() => _savedProducts.Clear();

        public List<string> GetActive() => _savedProducts;

        public int GetNumActive() => _savedProducts.Count;

        public bool IsActive(string entity) => _savedProducts.Contains(entity);

        public void Toggle(string entity)
        {
            if (_savedProducts.Contains(entity))
            {
                _savedProducts.Remove(entity);
            }
            else
            {
                _savedProducts.Add(entity);
            }
        }
    }
}
