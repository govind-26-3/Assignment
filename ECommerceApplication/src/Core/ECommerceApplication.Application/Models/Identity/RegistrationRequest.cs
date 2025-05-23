﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}

