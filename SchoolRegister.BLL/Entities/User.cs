using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.BLL.Entities
{
    public class User :IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
