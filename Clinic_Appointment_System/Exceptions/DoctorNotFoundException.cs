namespace Clinic_Appointment_System.Exceptions
{
    public class DoctorNotFoundException : ApplicationException
    {
        public DoctorNotFoundException(int doctorId):base($"Doctor with ID {doctorId} not found.")
        {
        }
    }
}
