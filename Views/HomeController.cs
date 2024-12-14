using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Views
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
