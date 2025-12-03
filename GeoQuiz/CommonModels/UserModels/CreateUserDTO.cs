using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.UserModels
{
    public class CreateUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public CreateUserDTO(string email, string password, string username)
        {
            Email = email;
            Password = password;
            Username = username;
        }
    }

   
}
