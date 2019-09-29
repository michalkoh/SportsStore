using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewModels;

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

        public ViewResult List(string category, int page = 1)
        {
            return View(
                new ProductsListViewModel()
                {
                    Products = this.productRepository.Products
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.Id)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems =  this.productRepository.Products.Count()
                    },
                    ProductCategory = category
                });
        }
    }
}
