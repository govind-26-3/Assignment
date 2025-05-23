﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BoilerPlate.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    }
}
