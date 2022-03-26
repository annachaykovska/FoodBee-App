using FoodBee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBee.Services
{
    public class MapLayerService<T> : IFoodBeeService<MapLayer>
    {
        private List<string> _activeLayers;

        public MapLayerService()
        {
            _activeLayers = new List<string>();
        }

        public Task InitializeAsync()
        {
            throw new System.NotImplementedException();
        }

        public List<MapLayer> GetAll()
        {
            return new List<MapLayer>()
            {
                new MapLayer { Name = "Food", IconClass = "fa-utensils" },
                new MapLayer { Name = "Drinks", IconClass = "fa-whiskey-glass" },
                new MapLayer { Name = "Water", IconClass = "fa-faucet" },
                new MapLayer { Name = "Bathrooms", IconClass = "fa-restroom" },
                new MapLayer { Name = "First Aid", IconClass = "fa-kit-medical" },
                new MapLayer { Name = "Security", IconClass = "fa-shield" },
                new MapLayer { Name = "ATMS", IconClass = "fa-credit-card" }
            };
        }

        public List<string> GetActive() => _activeLayers;

        public void ClearActive() => _activeLayers.Clear();

        public int GetNumActive() => this._activeLayers.Count;

        public void Toggle(string layer)
        {
            if (this._activeLayers.Contains(layer))
            {
                this._activeLayers.Remove(layer);
            }
            else
            {
                this._activeLayers.Add(layer);
            }
        }

        public bool IsActive(string entity) => this._activeLayers.Contains(entity);
    }
}
