using EmployeeHandlerSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeHandlerSystem.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string session = HttpContext.Session.GetString("sessionEmployeeLogIn");

            if (string.IsNullOrEmpty(session)) return null;

            EmployeeModel employee = JsonConvert.DeserializeObject<EmployeeModel>(session);

            return View(employee);
        }
    }
}
