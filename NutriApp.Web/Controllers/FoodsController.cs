using Microsoft.AspNetCore.Mvc;
using NutriApp.Web.Models;

namespace NutriApp.Web.Controllers
{
    public class FoodsController : Controller
    {
        private static readonly List<Food> Foods = new();
        public IActionResult Index()
        {
            return View(Foods);
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            if (string.IsNullOrWhiteSpace(food.Name))
            {
                ModelState.AddModelError(nameof(food.Name), "El nombre del alimento es obligatorio");
            }

            if (food.Calories < 0 || food.Proteins < 0)
            {
                ModelState.AddModelError(string.Empty, "Las calorías y las proteinas no pueden ser negativas");
            }

            if (!ModelState.IsValid)
            {
                return View("Index", Foods);
            }

            food.Id = Foods.Count == 0 ? 1: Foods.Max(item  => item.Id) + 1;
            Foods.Add(food);

            return RedirectToAction(nameof(Index));
        }
    }
}
