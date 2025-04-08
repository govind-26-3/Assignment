using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlate.Domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }

        public string Speciality { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
