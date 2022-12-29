using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class ProductController : Infrastructure.BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
