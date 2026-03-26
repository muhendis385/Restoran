using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Serializers;

namespace AkademiQMongoDb.ViewComponents
{
    public class _DefaultProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            var list = values.Take(3).ToList();
            return View(list);
        }
    }
}
