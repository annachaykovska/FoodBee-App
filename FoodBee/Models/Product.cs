using Newtonsoft.Json;

namespace FoodBee.Models
{
    public class Product
    {

        public string Vendor { get; set; }        // refers to the vendor who makes this propduct
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        // Dietary flags
        public int Glutenfree { get; set; }
        public int Vegetarian { get; set; }
        public int Vegan { get; set; }
        public int Lactose { get; set; }
        public int Nuts { get; set; }
        

        // Product type flags
        private int Food { get; set; }
        private int Drink { get; set; }

        public string? ImageUrl { get; set; }


    }
}
