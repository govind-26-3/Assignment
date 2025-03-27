using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.API.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
