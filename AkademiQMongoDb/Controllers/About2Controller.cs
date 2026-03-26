using AkademiQMongoDb.Dtos.AboutSection1;
using AkademiQMongoDb.Dtos.AboutSection2;
using AkademiQMongoDb.Services.About1Services;
using AkademiQMongoDb.Services.About2Services;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class About2Controller : Controller
    {
        private readonly IAbout2Service _about2Service;

        public About2Controller(IAbout2Service about2Service)
        {
            _about2Service = about2Service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> About2List()
        {
            var value = await _about2Service.GetAllAbout2Async();
            if (value == null)
            {
                return View(new List<ResultAbout2Dto>());
            }
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAbout2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout2(CreateAbout2Dto _createAbout2Dto)
        {
            await _about2Service.CreateAbout2Async(_createAbout2Dto);
            return RedirectToAction("About2List");
        }
        public async Task<IActionResult> DeleteAbout2(string id)
        {
            await _about2Service.DeleteAbout2Async(id);
            return RedirectToAction("About2List");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout2(string id)
        {
            var values = await _about2Service.GetAbout2ByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout2(UpdateAbout2Dto _updateAbout2Dto)
        {
            await _about2Service.UpdateAbout2Async(_updateAbout2Dto);
            return RedirectToAction("About2List");
        }
    }
}
