using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EmployeeHandlerSystem.Domain.Models
{
    public class EmployeeLoginModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
