using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AkademiQMongoDb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult _AdminLayout() 
        {
            return View();
        }
    }
}
