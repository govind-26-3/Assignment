using System.ComponentModel.DataAnnotations;
using Clinic_Appointment_System.Constants;
using Microsoft.AspNetCore.Identity;

namespace Clinic_Appointment_System.Models
{

    public class User : IdentityUser
    //public class User
    {
        

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

       
    
        
    }
}
