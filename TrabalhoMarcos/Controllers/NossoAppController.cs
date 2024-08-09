using Microsoft.AspNetCore.Mvc;

namespace TrabalhoMarcos.Controllers
{
    public class NossoAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
