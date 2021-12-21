namespace ZakladOptyczny.Models.Utilities
{
    public class Appointment
    {
        public Prescription Prescription { get; set; }
        public bool? IsAttended { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }

        public Appointment(Prescription prescription, bool isAttended, string note, DateTime date)
        {
            Prescription = prescription;
            IsAttended = isAttended;    
            Note = note;
            Date = date;
        }
    }
}
