using System;
using System.Collections.Generic;
using System.Text;

namespace UESAN.SHOPPING.CORE.core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }


    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }


    }
}
