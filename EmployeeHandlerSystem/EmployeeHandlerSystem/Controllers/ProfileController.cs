using EmployeeHandlerSystem.Domain.Models;
using EmployeeHandlerSystem.Helper.Interface;
using EmployeeHandlerSystem.Integration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeHandlerSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IApiLoginIntegration _apiLoginIntegration;
        private readonly ISessionEmployee _sessionEmployee;

        public ProfileController(IApiLoginIntegration apiLoginIntegration, ISessionEmployee sessionEmployee)
        {
            _apiLoginIntegration = apiLoginIntegration;
            _sessionEmployee = sessionEmployee;
        }

        public IActionResult Index()
        {
            EmployeeModel employee = _sessionEmployee.GetSessionEmployee();
            return View(employee);
        }


        public IActionResult UpdateProfile()
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> ConfirmeUpdate(EmployeeModel employee)
        {
            EmployeeModel employeeGet = await _apiLoginIntegration.GetEmployeeByName(employee.Name);

            return View();
        }
    }
}
