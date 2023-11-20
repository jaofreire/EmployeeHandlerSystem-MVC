using EmployeeHandlerSystem.Domain.Models;


namespace EmployeeHandlerSystem.Helper.Interface
{
    public interface ISessionEmployee
    {
        void AddSessionEmployee(EmployeeModel employee);
        void RemoveSessionEmployee();
        EmployeeModel GetSessionEmployee();
    }
}
