using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductList()
        {
            var value = await _productService.GetAllProductAsync(); 
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto _createProductDto)
        {
            await _productService.CreateProductAsync(_createProductDto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto _updateProductDto)
        {
            await _productService.UpdateProductAsync(_updateProductDto);
            return RedirectToAction("ProductList");
        }

    }
}
