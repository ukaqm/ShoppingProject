namespace ShoppingProject.Models
{
    public class EFShoppingRepository : IShoppingRepository
    {
        private ShoppingProjectContext _context;
        public EFShoppingRepository(ShoppingProjectContext temp) {
            _context = temp;
        }

        public IQueryable<Item> Items => _context.Items;
    }
}
