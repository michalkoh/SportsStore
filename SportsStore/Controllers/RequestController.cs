using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class RequestController : Controller
    {
        public ViewResult Create(int productId)
        {
            return View();
        }
    }
}
