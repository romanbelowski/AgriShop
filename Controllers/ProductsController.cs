using Microsoft.AspNetCore.Mvc;

namespace WSLab.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
