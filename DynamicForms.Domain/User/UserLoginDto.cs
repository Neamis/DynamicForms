using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DynamicForms.Domain.User
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}