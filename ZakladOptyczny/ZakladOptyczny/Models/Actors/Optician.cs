using ZakladOptyczny.Models.Interfaces;
using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Actors
{
    public class Optician : User, ICalendarManager
    {
        public Optician(string name, string surname, string pesel, string email, int dbId) : base(name, surname, pesel, email, dbId)
        {
            // base constructor already called at this point
        }

        public List<Appointment> GetAppointmentsCalendar()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetPastAppointments()
        {
            throw new NotImplementedException();
        }

        public Appointment AddNote(Appointment appointment, string note)
        {
            appointment.Note = note;
            return appointment;
        }

        public Appointment AddPrescription(Appointment appointment, Prescription prescription)
        {
            appointment.Prescription = prescription;
            return appointment;
        }
    }
}
