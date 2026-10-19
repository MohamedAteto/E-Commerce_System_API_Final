using System.ComponentModel.DataAnnotations;

namespace E_Commerce_System_API_Final.DTOs.AuthDTOs
{
    public class Register
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "Customer";

    }
}
