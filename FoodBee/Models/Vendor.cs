namespace FoodBee.Models
{
    public class Vendor
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public string? ImageUrl { get; set; }        // of the form "Images/Vendor/{Name}.png if not specified (remote) example: "Images/Vendor/dd.png

        public int Booth { get; set; }      // arbitrary booth number
    }
}
