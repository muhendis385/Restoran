using AkademiQMongoDb.Services.FeatureServices;
using AkademiQMongoDb.Services.OrderServices;
using AkademiQMongoDb.Services.ProductServices;
using AkademiQMongoDb.Services.SubscriberServices;
using AkademiQMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ISubscriberServices _subscriberService;
        private readonly ITestimonialService _testimonialService;
        private readonly IFeatureService _featureService;
        public DashboardController(IOrderService orderService, IProductService productService, 
            ISubscriberServices subscriberServices, ITestimonialService testimonialService, IFeatureService featureService)
        {
            _orderService = orderService;
            _productService = productService;
            _subscriberService = subscriberServices;
            _testimonialService = testimonialService;
            _featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Son 5 Yorum (Tarihe göre yeniden eskiye)
            var testimonials = await _testimonialService.GetAllTestimonialAsync();
            ViewBag.Last5Testimonials = testimonials.OrderByDescending(x => x.TestimonialId).Take(5).ToList();

            // 2. Son 5 Abone
            var subscribers = await _subscriberService.GetAllSubscriberAsync();
            ViewBag.Last5Subscribers = subscribers.OrderByDescending(x => x.SubscriptionDate).Take(5).ToList();

            // 3. Son 5 Sipariş
            var orders = await _orderService.GetAllOrderAsync();
            ViewBag.Last5Orders = orders.OrderByDescending(x => x.OrderDate).Take(5).ToList();

            // 5. Son Eklenen Ürün (Model olarak gönderiyoruz)
            var products = await _productService.GetAllProductAsync();
            var lastProduct = products.LastOrDefault();

            return View(lastProduct);
        }
    }
}
