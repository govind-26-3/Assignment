using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
