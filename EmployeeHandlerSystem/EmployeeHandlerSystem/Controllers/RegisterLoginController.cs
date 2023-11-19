using EmployeeHandlerSystem.Domain.DTOs;
using EmployeeHandlerSystem.Domain.Models;
using EmployeeHandlerSystem.Integration;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandlerSystem.Controllers
{
    public class RegisterLoginController : Controller
    {
        private readonly IApiLoginIntegration _apiLoginIntegration;

        public RegisterLoginController(IApiLoginIntegration apiLoginIntegration)
        {
            _apiLoginIntegration = apiLoginIntegration;
        }

        public IActionResult EnterLoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeLoginModel newEmployee)
        {

            try
            {
                await _apiLoginIntegration.RegisterNewEmployee(newEmployee);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception error)
            {
                Console.WriteLine($"Erro ao cadastras usuario: {error.Message}");
                Console.WriteLine($"Detalhes: {error.InnerException.Message}");
                return RedirectToAction("EnterLoginPage");
            }


        }
    }
}
