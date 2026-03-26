using AkademiQMongoDb.Services.About1Services;
using AkademiQMongoDb.Services.About2Services;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _DefaultAboutSection2ComponentPartial : ViewComponent
    {
        private readonly IAbout2Service _about2Service;

        public _DefaultAboutSection2ComponentPartial(IAbout2Service about2Service)
        {
            _about2Service = about2Service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _about2Service.GetAllAbout2Async();
            return View(value);
        }
    }
}
