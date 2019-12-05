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
                    Products = this.productRepository.GetProducts()
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.Id)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems =  category == null ? this.productRepository.GetProducts().Count() : this.productRepository.GetProducts().Count(p => p.Category == category)
                    },
                    ProductCategory = category
                });
        }
    }
}
