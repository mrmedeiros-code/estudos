using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index(string id)
        {
            return View();
        }

    }
}
