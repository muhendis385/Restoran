using AkademiQMongoDb.Dtos.StoryVideoDto;
using AkademiQMongoDb.Services.StoryVideoServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class StoryVideoController : Controller
    {
        private readonly IStoryVideoService _storyVideoService;

        public StoryVideoController(IStoryVideoService about1Service)
        {
            _storyVideoService = about1Service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> StoryVideoList()
        {
            var value = await _storyVideoService.GetStoryVideoAsync();
            if (value == null)
            {
                return View(new ResultVideoDto());
            }
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateStoryVideo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStoryVideo(CreateVideoDto _createVideoDto)
        {
            await _storyVideoService.CreateStoryVideoAsync(_createVideoDto);
            return RedirectToAction("StoryVideoList");
        }
        public async Task<IActionResult> DeleteStoryVideo(string id)
        {
            await _storyVideoService.DeleteStoryVideoAsync(id);
            return RedirectToAction("StoryVideoList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStoryVideo(string id)
        {
            var values = await _storyVideoService.GetStoryVideoByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStoryVideo(UpdateVideoDto _updateStoryVideoDto)
        {
            await _storyVideoService.UpdateStoryVideoAsync(_updateStoryVideoDto);
            return RedirectToAction("StoryVideoList");
        }
    }
}
