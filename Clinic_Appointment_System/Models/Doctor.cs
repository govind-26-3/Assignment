using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Appointment_System.Models
{
    public class Doctor
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        //[MaxLength(25)]
        //[Required]
        public string Name { get; set; }

        public string Speciality { get; set; }
        public List<Appointment> Appointments { get; set; }


    }
}
