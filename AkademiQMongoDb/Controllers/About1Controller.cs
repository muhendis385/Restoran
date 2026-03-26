using AkademiQMongoDb.Dtos.AboutSection1;
using AkademiQMongoDb.Dtos.FeatureDto;
using AkademiQMongoDb.Services.About1Services;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class About1Controller : Controller
    {
        private readonly IAbout1Service _about1Service;

        public About1Controller(IAbout1Service about1Service)
        {
            _about1Service = about1Service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> About1List()
        {
            var value = await _about1Service.GetActiveAbout1Async();
            if (value == null)
            {
                return View(new ResultAbout1Dto());
            }
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAbout1()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout1(CreateAbout1Dto _createAbout1Dto)
        {
            await _about1Service.CreateAbout1Async(_createAbout1Dto);
            return RedirectToAction("About1List");
        }
        public async Task<IActionResult> DeleteAbout1(string id)
        {
            await _about1Service.DeleteAbout1Async(id);
            return RedirectToAction("About1List");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout1(string id)
        {
            var values = await _about1Service.GetAbout1ByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout1(UpdateAbout1Dto _updateAbout1Dto)
        {
            await _about1Service.UpdateAbout1Async(_updateAbout1Dto);
            return RedirectToAction("About1List");
        }
    }
}
