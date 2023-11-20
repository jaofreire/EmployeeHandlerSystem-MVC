using EmployeeHandlerSystem.Domain.DTOs;
using EmployeeHandlerSystem.Domain.Models;
using EmployeeHandlerSystem.Helper.Interface;
using EmployeeHandlerSystem.Infraestructure.Data;
using EmployeeHandlerSystem.Integration;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandlerSystem.Controllers
{
    public class RegisterLoginController : Controller
    {
        private readonly IApiLoginIntegration _apiLoginIntegration;
        private readonly ISessionEmployee _sessionEmployee;

        public RegisterLoginController(IApiLoginIntegration apiLoginIntegration, ISessionEmployee sessionEmployee)
        {
            _apiLoginIntegration = apiLoginIntegration;
            _sessionEmployee = sessionEmployee;
        }

        public IActionResult EnterLoginPage()
        {
            return View();
        }

        public IActionResult EnterSignInPage()
        {
            if (_sessionEmployee.GetSessionEmployee() != null) return RedirectToAction("Index", "Home");
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

        public async Task<IActionResult> ConfirmeLogin(EmployeeLoginModel employee)
        {
            try
            {
                var employeeConfirm = await _apiLoginIntegration.GetEmployeeByName(employee.Name);

                if (employee.Name == employeeConfirm.Name && employee.Email == employeeConfirm.Email && employee.Password == employeeConfirm.Password)
                {
                    _sessionEmployee.AddSessionEmployee(employeeConfirm);
                    return RedirectToAction("Index", "Home");
                }
                TempData["ErrorMessage"] = "INVALID CREDENTIALS!!";
                return RedirectToAction("EnterSignInPage");
            }
            catch (Exception error)
            {
                await Console.Out.WriteLineAsync($"It seems ocorred a error in LOGIN THE SYSTEM, try again please, DETAILS: {error.Message}");
                await Console.Out.WriteLineAsync(error.InnerException.Message);

                return RedirectToAction("EnterSignInPage");
            }
           
        }

        public IActionResult LogOut()
        {
            _sessionEmployee.RemoveSessionEmployee();

            return RedirectToAction("EnterSignInPage");
        }

    }
}
