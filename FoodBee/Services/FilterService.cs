using FoodBee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBee.Services
{
    public class FilterService<T> : IFoodBeeService<Filter>
    {
        private List<string> _activeFilters;

        public FilterService()
        {
            _activeFilters = new List<string>();
        }

        public Task InitializeAsync()
        {
            throw new System.NotImplementedException();
        }

        public void ClearActive() => this._activeFilters.Clear();

        public List<string> GetActive() => _activeFilters;

        public List<Filter> GetAll()
        {
            return new List<Filter>()
            {
                // Product type filters
                new Filter { Name = "Food", Category = "Type", DataField = "Food" },
                new Filter { Name = "Drinks", Category = "Type", DataField = "Drink" },
                new Filter { Name = "Other", Category= "Type", DataField = null },

                // Dietary filters
                new Filter { Name = "Gluten Free", Category = "Dietary", DataField = "Glutenfree" },
                new Filter { Name = "Vegetarian", Category = "Dietary", DataField = "Vegetarian" },
                new Filter { Name = "Vegan", Category = "Dietary", DataField = "Vegan" },
                new Filter { Name = "Lactose Free", Category = "Dietary", DataField = "Lactose" },
                new Filter { Name = "No Nuts", Category = "Dietary", DataField = "Nuts" },
                new Filter { Name = "Alcoholic", Category = "Dietary", DataField = null },


                // Price filters 
                new Filter { Name = "$", Category = "Price", DataField = null },
                new Filter { Name = "$$", Category = "Price", DataField = null },
                new Filter { Name = "$$$", Category = "Price", DataField = null }


                // Accessibility filters... may not need these
                //new Filter { Name = "Wheelchair Friendly", Category = "Accessibility" }

            };
        }

        public int GetNumActive() => this._activeFilters.Count;

        public bool IsActive(string entity) => this._activeFilters.Contains(entity);

        public void Toggle(string entity)
        {
            if (_activeFilters.Contains(entity))
            {
                _activeFilters.Remove(entity);  
            }
            else
            {
                _activeFilters.Add(entity);
            }
        }
    }
}
