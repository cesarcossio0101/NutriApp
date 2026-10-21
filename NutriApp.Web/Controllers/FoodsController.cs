using Microsoft.AspNetCore.Mvc;

namespace NutriApp.Web.Controllers
{
    public class FoodsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
