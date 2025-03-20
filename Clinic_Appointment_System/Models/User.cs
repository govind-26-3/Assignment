﻿using Clinic_Appointment_System.Constants;

namespace Clinic_Appointment_System.Models
{

    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    
        public Role Role { get; set; }
    }
}
