using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Models;

namespace ShoppingProject.Components
{
    public class ItemTypesViewComponent : ViewComponent
    {
        private IShoppingRepository _shopRepo;

        public ItemTypesViewComponent(IShoppingRepository temp) 
        {
            _shopRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectItemType = RouteData?.Values["itemType"];

            var itemTypes = _shopRepo.Items
                .Select(x => x.ItemName)
                .Distinct()
                .OrderBy(x => x);

            return View(itemTypes);
        }

    }
}
