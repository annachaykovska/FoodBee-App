using FoodBee.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FoodBee.Services
{
    /// <summary>
    /// This service handles data access for FoodBee Vendors from JSON HTTP response and bookmark/saving vendors.
    /// </summary>
    /// <typeparam name="T">FoodBee.Models.Vendor</typeparam>
    public class VendorService<T> : IFoodBeeService<Vendor>
    {
        private List<Vendor> _allVendors;
        private List<string> _savedVendors;
        private HttpClient _http;

        public VendorService(HttpClient http)
        {
            _http = http;
            _savedVendors = new List<string>();
        }

        public async Task InitializeAsync()
        {
            Vendor[] vendors = await _http.GetFromJsonAsync<Vendor[]>("data/vendors.json");
            _allVendors = vendors.ToList();
        }

        public List<Vendor> GetAll() => _allVendors != null ? _allVendors : new List<Vendor>();

        public void ClearActive() => _savedVendors.Clear();

        public List<string> GetActive() => _savedVendors;

        public int GetNumActive() => _savedVendors.Count;

        public bool IsActive(string entity) => _savedVendors.Contains(entity);

        public void Toggle(string entity)
        {
            if (_savedVendors.Contains(entity))
            {
                _savedVendors.Remove(entity);
            }
            else
            {
                _savedVendors.Add(entity);
            }
        }
    }
}
