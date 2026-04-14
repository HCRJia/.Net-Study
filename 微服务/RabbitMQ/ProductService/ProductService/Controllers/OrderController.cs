using Microsoft.AspNetCore.Mvc;

namespace EBusiness.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
