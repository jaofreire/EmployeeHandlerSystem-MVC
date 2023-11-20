using EmployeeHandlerSystem.Domain.DTOs;
using EmployeeHandlerSystem.Domain.Models;
using Refit;

namespace EmployeeHandlerSystem.Integration.Refit
{
    public interface IApiLoginIntegrationRefit
    {
        [Post("/api/v1/authenticate")]
        Task<string> AuthenticateToken(string name);


        [Post("/api/v1/Employee/Register")]
        Task<EmployeeModel> RegisterEmployee(EmployeeLoginModel newEmployee);

        [Get("/api/v1/Employee/GetAll")]
        Task<List<EmployeeDTO>> GetAllEmployee();

        [Get("/api/v1/Employee/GetById/{id}")]
        Task<EmployeeDTO> GetEmployeeById(int id);

        [Get("/api/v1/Employee/GetByName/{name}")]
        Task<EmployeeModel> GetEmployeeByName(string name);

        [Put("/api/v1/Employee/Update/{id}")]
        Task<EmployeeModel> UpdateEmployee(EmployeeModel employee, int id);


        [Post("/api/v1/JustAuthorized")]
        Task<EmployeeModel> RegisterJustAuthorized(EmployeeModel newEmployee);

        [Patch("/api/v1/updaterole/{id}")]
        Task<EmployeeModel> UpdateRole(int id, string newRole);

        [Delete("/api/v1/delete/{id}")]
        Task<bool> DeleteEmployee(int id);
    }
}
