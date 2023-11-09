using Microsoft.AspNetCore.Mvc;
using WSLab.Data;
using WSLab.Models;
using WSLab.Models.Domain;

namespace WSLab.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataBaseContext dataBaseContext;

        public ProductsController(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductRequest)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                Category = addProductRequest.Category,
                Price = addProductRequest.Price,
                Image = addProductRequest.Image,
                AvaibleQuantity = addProductRequest.AvaibleQuantity

        
            };


            await dataBaseContext.Products.AddAsync(product);
            await dataBaseContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }






    }

}
