namespace Clinic_Appointment_System.Exceptions
{
    public class AppointmentNotFoundException : ApplicationException
    {
        public AppointmentNotFoundException(int appointmentId)
        : base($"Appointment with ID {appointmentId} not found.")
        {
        }
    }
}
