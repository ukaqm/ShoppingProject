namespace ShoppingProject.Models
{
    public interface IShoppingRepository
    {
        public IQueryable<Item> Items { get; }
    }
}
