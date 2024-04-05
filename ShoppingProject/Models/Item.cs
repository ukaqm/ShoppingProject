using System.ComponentModel.DataAnnotations;

namespace ShoppingProject.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
