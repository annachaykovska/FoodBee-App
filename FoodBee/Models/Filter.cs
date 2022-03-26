
namespace FoodBee.Models
{
    public class Filter
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string? DataField { get; set; }   // corrsponds to the key in wwwroot/data/products.json like "nuts" or "glutenfree"
    }

    public enum SortPredicate
    {
        Closest,
        Cheapest,
        Newest
    }
}
