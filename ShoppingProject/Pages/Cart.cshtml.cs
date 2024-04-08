using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingProject.Infrastructure;
using ShoppingProject.Models;

namespace ShoppingProject.Pages
{
    public class CartModel : PageModel
    {
        private IShoppingRepository _repo;

        public Cart Cart { get; set; }

        public CartModel(IShoppingRepository temp, Cart cartService)
        {
            _repo = temp;
            Cart = cartService;
        }
        
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int ItemId, string returnUrl) 
        {
            Item p = _repo.Items
                .FirstOrDefault(x => x.ItemId == ItemId);
            if (p != null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(p, 1);
                //HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage (new {returnUrl = returnUrl});
        }

        public IActionResult OnPostRemove (int itemId, string returnUrl) 
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Item.ItemId == itemId).Item);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
