using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Models;
using ShoppingProject.Models.ViewModels;
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

        public IActionResult Index(int pageNum, string? itemType)
        {

            int pageSize = 5;

            var FullObject = new PaginationListViewModel
            {
                Items = _repo.Items
                .Where(x => x.ItemName == itemType || itemType == null)
                .OrderBy(x => x.ItemName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = itemType == null ? _repo.Items.Count() : _repo.Items.Where(x => x.ItemName == itemType).Count()
                },

                CurrentItemType = itemType

            };
            return View(FullObject);
        }
    }
}
