namespace Clinic_Appointment_System.Exceptions
{
    public class DoctorNotFoundException : ApplicationException
    {
        public DoctorNotFoundException(string? msg):base(msg)
        {
        }
    }
}
