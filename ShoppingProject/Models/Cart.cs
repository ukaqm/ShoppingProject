namespace ShoppingProject.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Item p, int quantity)
        {
            if (p.Amount > 0) 
            {
                CartLine? line = Lines
                .Where(x => x.Item.ItemId == p.ItemId)
                .FirstOrDefault();

                //Has item already been added to the cart
                if (line == null)
                {
                    Lines.Add(new CartLine()
                    {
                        Item = p,
                        Quantity = quantity
                    });
                }
                else
                {
                    line.Quantity += quantity;
                }
            }  
        }

        public virtual void RemoveLine(Item p) => Lines.RemoveAll(x => x.Item.ItemId == p.ItemId);

        public virtual void Clear() => Lines.Clear();

        public decimal CalculateTotal() => Lines.Sum(x => x.Item.Price * x.Quantity);


        public class CartLine
        {
            public int CartLineId {  get; set; }
            public Item Item { get; set; }

            public int Quantity { get; set; }
        }
    }
}
