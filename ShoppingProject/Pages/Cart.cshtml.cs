using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingProject.Infrastructure;
using ShoppingProject.Models;

namespace ShoppingProject.Pages
{
    public class CartModel : PageModel
    {
        private IShoppingRepository _repo;

        public CartModel(IShoppingRepository temp)
        {
            _repo = temp;
        }
        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int ItemId, string returnUrl) 
        {
            Item p = _repo.Items
                .FirstOrDefault(x => x.ItemId == ItemId);
            if (p != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(p, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage (new {returnUrl = returnUrl});
        }
    }
}
