using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Models;
using System.Diagnostics;

namespace ShoppingProject.Controllers
{
    public class HomeController : Controller
    {
        private IShoppingRepository _repo;
        public HomeController(IShoppingRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var ItemInfo = _repo.Items;

            return View(ItemInfo);
        }
    }
}
