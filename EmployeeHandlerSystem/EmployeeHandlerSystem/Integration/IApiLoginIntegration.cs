using EmployeeHandlerSystem.Domain.DTOs;
using EmployeeHandlerSystem.Domain.Models;

namespace EmployeeHandlerSystem.Integration
{
    public interface IApiLoginIntegration
    {
        Task<string> AuthenticateToken(string name);


        Task<EmployeeModel> RegisterNewEmployee(EmployeeLoginModel newEmployee);
        Task<List<EmployeeDTO>> GetAllEmployee();
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<EmployeeModel> GetEmployeeByName(string name);
        Task<EmployeeModel> UpdateEmployee(EmployeeModel employee, int id);


        Task<EmployeeModel> RegisterJustAuthorized(EmployeeModel newEmployee);
        Task<EmployeeModel> UpdateRole(int id, string newRole);
        Task<bool> DeleteEmployee(int id);
    }
}
