namespace BoilerPlate.Domain.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public Doctor Doctor { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        BOOKED=1,

        CANCELLED
    }
}