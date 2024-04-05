using System.ComponentModel.DataAnnotations;

namespace ShoppingProject.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string? ItemName { get; set; } = "N/A";
        public string? ItemDescription { get; set; } = "N/A";
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
