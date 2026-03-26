using AkademiQMongoDb.Dtos.FeatureDto;
using AkademiQMongoDb.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
   
        public class FeatureController : Controller
        {
            private readonly IFeatureService _featureService;

            public FeatureController(IFeatureService featureService)
            {
                _featureService = featureService;
            }

            // Admin panelinde mevcut Feature'ı görüntülemek için
            public async Task<IActionResult> FeatureList()
            {
                
                var values = await _featureService.GetActiveFeatureAsync();
                if (values == null)
                {
                    return View(new ResultFeatureDto());
                }
            return View(values);
            }

            [HttpGet]
            public IActionResult CreateFeature()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
            {
                await _featureService.CreateFeatureAsync(createFeatureDto);
                return RedirectToAction("FeatureList");
            }

            public async Task<IActionResult> DeleteFeature(string id)
            {
                await _featureService.DeleteFeatureAsync(id);
                return RedirectToAction("FeatureList");
            }

            [HttpGet]
            public async Task<IActionResult> UpdateFeature(string id)
            {
                var value = await _featureService.GetFeatureByIdAsync(id);
                return View(value);
            }

            [HttpPost]
            public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
            {
                await _featureService.UpdateFeatureAsync(updateFeatureDto);
                // Güncelleme bitince tekrar detay/liste sayfasına dön
                return RedirectToAction("FeatureList");
            }
        }
    }

