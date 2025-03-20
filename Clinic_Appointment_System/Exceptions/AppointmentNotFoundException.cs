namespace Clinic_Appointment_System.Exceptions
{
    public class AppointmentNotFoundException : ApplicationException
    {
        public AppointmentNotFoundException(string? msg)
        : base(msg)
        {
        }
    }
}
