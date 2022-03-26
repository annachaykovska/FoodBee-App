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
                new Filter { Name = "Food", Category = "Type", DataField = "food" },
                new Filter { Name = "Drinks", Category = "Type", DataField = "drink" },
                new Filter { Name = "Other", Category= "Type" },

                // Dietary filters
                new Filter { Name = "Gluten Free", Category = "Dietary", DataField = "glutenfree" },
                new Filter { Name = "Vegetarian", Category = "Dietary", DataField = "vegetarian" },
                new Filter { Name = "Vegan", Category = "Dietary", DataField = "vegan" },
                new Filter { Name = "Lactose Free", Category = "Dietary", DataField = "lactose" },
                new Filter { Name = "No Nuts", Category = "Dietary", DataField = "nuts" },
                new Filter { Name = "Alcoholic", Category = "Dietary" },


                // Price filters 
                new Filter { Name = "$", Category = "Price" },
                new Filter { Name = "$$", Category = "Price" },
                new Filter { Name = "$$$", Category = "Price" }


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
