using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandlerSystem.Controllers
{
    public class RegisterLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
