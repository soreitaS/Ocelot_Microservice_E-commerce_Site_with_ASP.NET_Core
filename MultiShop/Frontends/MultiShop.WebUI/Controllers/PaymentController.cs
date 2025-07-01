using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "Mikroservis";
            ViewBag.directory2 = "Ödeme Ekranı";
            ViewBag.directory3 = "Kart ile Ödeme";
            return View();
        }
    }
}
