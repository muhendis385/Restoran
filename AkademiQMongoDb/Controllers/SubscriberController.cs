using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class SubscriberController : Controller
    {
        
            private readonly ISubscriberServices _subscriberService;

            public SubscriberController(ISubscriberServices subscriberService)
            {
                _subscriberService = subscriberService;
            }

            public async Task<IActionResult> SubscriberList()
            {
                var values = await _subscriberService.GetAllSubscriberAsync();
                return View(values);
            }

            public async Task<IActionResult> DeleteSubscriber(string id)
            {
                await _subscriberService.DeleteSubscriberAsync(id);
                return RedirectToAction("SubscriberList");
            }
        
    }
}
