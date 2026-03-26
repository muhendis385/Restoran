using AkademiQMongoDb.Services.About1Services;
using AkademiQMongoDb.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _DefaultAboutSection1ComponentPartial : ViewComponent
    {
        private readonly IAbout1Service _about1Service;

        public _DefaultAboutSection1ComponentPartial(IAbout1Service about1Service)
        {
            _about1Service = about1Service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tek bir veri döndüren metodumuzu çağırıyoruz
            var value = await _about1Service.GetActiveAbout1Async();
            return View(value);
        }
    }
}
