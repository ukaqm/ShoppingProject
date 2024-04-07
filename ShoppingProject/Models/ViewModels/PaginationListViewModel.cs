namespace ShoppingProject.Models.ViewModels
{
    public class PaginationListViewModel
    {
        public IQueryable<Item> Items { get; set; }
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo(); 

        public string? CurrentItemType { get; set; }
    }
}
