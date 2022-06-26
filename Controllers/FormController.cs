using Microsoft.AspNetCore.Mvc;

namespace Webform.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
