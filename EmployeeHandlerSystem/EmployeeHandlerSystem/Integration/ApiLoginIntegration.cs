using EmployeeHandlerSystem.Domain.DTOs;
using EmployeeHandlerSystem.Domain.Models;
using EmployeeHandlerSystem.Integration.Refit;

namespace EmployeeHandlerSystem.Integration
{
    public class ApiLoginIntegration : IApiLoginIntegration
    {
        private readonly IApiLoginIntegrationRefit _refit;

        public ApiLoginIntegration(IApiLoginIntegrationRefit refit)
        {
            _refit = refit;
        }

        public async Task<string> AuthenticateToken(string name)
        {
            return await _refit.AuthenticateToken(name);
        }


        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
            return await _refit.GetAllEmployee();
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            return await _refit.GetEmployeeById(id);
        }

        public async Task<EmployeeModel> RegisterNewEmployee(EmployeeDTORegisterLogin newEmployee)
        {
            return await _refit.RegisterEmployee(newEmployee);
        }

        public async Task<EmployeeModel> UpdateEmployee(EmployeeModel employee, int id)
        {
            return await _refit.UpdateEmployee(employee, id);
        }


        public async Task<EmployeeModel> RegisterJustAuthorized(EmployeeModel newEmployee)
        {
            return await _refit.RegisterJustAuthorized(newEmployee);
        }

        public async Task<EmployeeModel> UpdateRole(int id, string newRole)
        {
            return await _refit.UpdateRole(id, newRole);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _refit.DeleteEmployee(id);
        }
    }
}
