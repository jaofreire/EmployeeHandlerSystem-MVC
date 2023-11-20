using EmployeeHandlerSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeHandlerSystem.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            string session = HttpContext.Session.GetString("sessionEmployeeLogIn");

            if (string.IsNullOrEmpty(session)) return null;

            EmployeeModel employee = JsonConvert.DeserializeObject<EmployeeModel>(session);

            return View(employee);
        }
    }
}
