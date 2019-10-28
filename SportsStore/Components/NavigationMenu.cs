using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenu : ViewComponent
    {
        private readonly IProductRepository productRepository;

        public NavigationMenu(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(this.productRepository.Products.Select(p => p.Category).Distinct().OrderBy(c => c));
        }
    }
}
