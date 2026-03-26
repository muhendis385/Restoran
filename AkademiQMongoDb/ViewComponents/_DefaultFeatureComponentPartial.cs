using AkademiQMongoDb.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultFeatureComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tek bir veri döndüren metodumuzu çağırıyoruz
            var value = await _featureService.GetActiveFeatureAsync();
            return View(value);
        }
    }
}
