using AkademiQMongoDb.Dtos.SubscribeDto;
using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ISubscriberServices _subscriberService;

        public DefaultController(ISubscriberServices subscriberService)
        {
            _subscriberService = subscriberService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var dto = new CreateSubscriberDto
                {
                    Email = email,
                    SubscriptionDate = DateTime.UtcNow.AddHours(3) // Türkiye Saati
                };

                await _subscriberService.CreateSubscriberAsync(dto);

                // Kullanıcıya mesaj göstermek için
                TempData["SubscribeSuccess"] = "Bültenimize başarıyla abone oldunuz!";

                return RedirectToAction("Index", "Default");
            }
            return RedirectToAction("Index", "Default");
        }


    }
}
