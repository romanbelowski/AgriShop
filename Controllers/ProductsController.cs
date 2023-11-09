using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task< IActionResult> Index()
        {
            var products = await dataBaseContext.Products.ToListAsync();
            return View(products);
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

        // Edit/View DB Table

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var product = await dataBaseContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                var viewModel = new UpdateProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Price = product.Price,
                    Image = product.Image,
                    AvaibleQuantity = product.AvaibleQuantity

                };
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }




    }

}
