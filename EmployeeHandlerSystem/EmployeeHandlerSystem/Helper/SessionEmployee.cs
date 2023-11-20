using EmployeeHandlerSystem.Domain.Models;
using EmployeeHandlerSystem.Helper.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeHandlerSystem.Helper
{
    public class SessionEmployee : ISessionEmployee
    {
        private readonly IHttpContextAccessor _httpContext;

        public SessionEmployee(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void AddSessionEmployee(EmployeeModel employee)
        {
            string valueSession = JsonConvert.SerializeObject(employee);
            _httpContext.HttpContext.Session.SetString("sessionEmployeeLogIn", valueSession);
        }

        public EmployeeModel GetSessionEmployee()
        {
            string session = _httpContext.HttpContext.Session.GetString("sessionEmployeeLogIn");

            if (string.IsNullOrEmpty(session)) return null;

            return JsonConvert.DeserializeObject<EmployeeModel>(session);
        }

        public void RemoveSessionEmployee()
        {
            _httpContext.HttpContext.Session.Remove("sessionEmployeeLogIn");
        }
    }
}
