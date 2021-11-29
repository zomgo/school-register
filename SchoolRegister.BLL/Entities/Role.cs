﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.BLL.Entities
{
    public class Role : IdentityRole<int>  

    {
        public RoleValue RoleValue { get; set; }
        public Role() { }

        public Role(string name, RoleValue roleValue) : base(name)
        {
            RoleValue = roleValue;
        }
    }
}
