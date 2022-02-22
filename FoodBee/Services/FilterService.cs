using FoodBee.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodBee.Services
{
    public static class FilterService
    {

        public static List<Filter> Filters { get; set; }
        
        static FilterService()
        {
            Filters = new List<Filter>()
            {
                new Filter
                {
                    Name = "Drinks",
                    Active = false,
                    IconSelector = "fa-whiskey-glass"
                },
                new Filter
                {
                    Name = "Food",
                    Active = false,
                    IconSelector = "fa-utensils"

                },
                new Filter
                {
                    Name = "Vegan",
                    Active = false,
                    IconSelector = "fa-leaf"
                },
                new Filter
                {
                    Name = "Events",
                    Active = false,
                    IconSelector = "fa-calendar"
                },
                new Filter
                {
                    Name = "Info",
                    Active = false,
                    IconSelector = "fa-circle-info"
                },
                new Filter
                {
                    Name = "Help",
                    Active = false,
                    IconSelector = "fa-circle-question"
                },
                new Filter
                {
                    Name = "Favourites",
                    Active = false,
                    IconSelector = "fa-heart"
                },
                new Filter
                {
                    Name = "Water",
                    Active = false,
                    IconSelector = "fa-faucet"
                },
                new Filter
                {
                    Name = "Washrooms",
                    Active = false,
                    IconSelector = "fa-restroom"
                },
                new Filter
                {
                    Name = "First aid",
                    Active = false,
                    IconSelector = "fa-kit-medical"
                },
                new Filter
                {
                    Name = "Security",
                    Active = false,
                    IconSelector = "fa-shield"
                },
                new Filter
                {
                    Name = "ATMs",
                    Active = false,
                    IconSelector = "fa-credit-card"
                },
                new Filter
                {
                    Name = "Accessible",
                    Active = false,
                    IconSelector = "fa-wheelchair"
                },
            }; ;
        }

        public static void ClearFilters() => Filters.ForEach(f => f.Active = false);
        public static void ToggleFilter(int i) => Filters.ElementAt(i).Active = !Filters[i].Active;
        public static void ToggleFilter(Filter f) => Filters.Find(filter => filter == f).Active = !Filters.Find(filter => filter == f).Active;
        public static int NumActive() => Filters.Aggregate(0, (acc, val) => val.Active ? acc + 1 : acc);
    }
}
