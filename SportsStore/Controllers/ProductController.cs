using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private const int PageSize = 4;
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            return View(this.productRepository.Products.OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }
    }
}
