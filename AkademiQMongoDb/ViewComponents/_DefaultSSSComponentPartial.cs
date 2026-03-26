using AkademiQMongoDb.Services.About1Services;
using AkademiQMongoDb.Services.SssServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _DefaultSSSComponentPartial : ViewComponent
    {
        private readonly ISssService _sssService;

        public _DefaultSSSComponentPartial(ISssService sssService)
        {
            _sssService = sssService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tek bir veri döndüren metodumuzu çağırıyoruz
            var value = await _sssService.GetAllSSSAsync();
            return View(value);
        }
    }
}
