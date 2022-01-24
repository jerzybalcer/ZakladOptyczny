using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string? Prescription { get; set; }
        public bool? IsAttended { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Appointment(int appointmentId, string prescription, bool isAttended, string note, DateTime date, User user)
        {
            AppointmentId = appointmentId;
            Prescription = prescription;
            IsAttended = isAttended;    
            Note = note;
            Date = date;
            UserId = user.UserId;
            User = user;
        }

        public Appointment() { }
    }
}
