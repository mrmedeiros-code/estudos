using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
