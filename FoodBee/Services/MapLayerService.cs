using FoodBee.Models;
using System.Collections.Generic;

namespace FoodBee.Services
{ 
    public class MapLayerService<T> : IFoodBeeService<MapLayer>
    {
        private List<MapLayer> _activeLayers;

        public List<MapLayer> GetAll()
        {
            return new List<MapLayer>()
            {
                new MapLayer { Name = "Food", IconClass = "fa-utensils" },
                new MapLayer { Name = "Drinks", IconClass = "fa-whiskey-glass" },
                new MapLayer { Name = "Water Fountains", IconClass = "fa-faucet" },
                new MapLayer { Name = "Bathrooms", IconClass = "fa-restroom" },
                new MapLayer { Name = "First Aid", IconClass = "fa-kit-medical" },
                new MapLayer { Name = "Security", IconClass = "fa-shield" },
                new MapLayer { Name = "ATMS", IconClass = "fa-credit-card" }
            };
        }

        public List<MapLayer> GetActive() => _activeLayers;

        public void ClearActive()
        {
            this._activeLayers = new List<MapLayer>();
        }

        public int GetNumActive() => this._activeLayers.Count;

        public void Toggle(MapLayer entity)
        {
            if (this._activeLayers.Contains(entity))
            {
                this._activeLayers.Remove(entity);
            }
            else
            {
                this._activeLayers.Add(entity);
            }
        }
    }
}
