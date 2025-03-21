using Clinic_Appointment_System.Constants;

namespace Clinic_Appointment_System.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public User Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Status Status { get; set; }
    }
}