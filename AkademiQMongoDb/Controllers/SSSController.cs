using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Dtos.SSSDto;
using AkademiQMongoDb.Services.SssServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class SSSController : Controller
    {
        private readonly ISssService _sssService;

        public SSSController(ISssService sssService)
        {
            _sssService = sssService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SSSList()
        {
            var value = await _sssService.GetAllSSSAsync();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSSS()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSSS(CreateSSSDto _createSSSDto)
        {
            await _sssService.CreateSSSAsync(_createSSSDto);
            return RedirectToAction("SSSList");
        }
        public async Task<IActionResult> DeleteSSS(string id)
        {
            await _sssService.DeleteSSSAsync(id);
            return RedirectToAction("SSSList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSSS(string id)
        {
            var values = await _sssService.GetSSSByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSSS(UpdateSSSDto _updateSSSDto)
        {
            await _sssService.UpdateSSSAsync(_updateSSSDto);
            return RedirectToAction("SSSList");
        }
    }
}
