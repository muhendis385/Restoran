using AkademiQMongoDb.Services.StoryVideoServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents
{
    public class _DefaultStoryVideoComponentPartial : ViewComponent
    {
        private readonly IStoryVideoService _storyVideoService;

        public _DefaultStoryVideoComponentPartial(IStoryVideoService storyVideoService)
        {
            _storyVideoService = storyVideoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tek bir veri döndüren metodumuzu çağırıyoruz
            var value = await _storyVideoService.GetStoryVideoAsync();
            return View(value);
        }
    }
}
