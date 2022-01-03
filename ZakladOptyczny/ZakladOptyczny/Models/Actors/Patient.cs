using ZakladOptyczny.Models.Interfaces;
using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Actors
{
    public class Patient : User, IAppointmentManager, ICalendarManager
    {
        public Patient(string name, string surname, string pesel, string email) : base(name, surname, pesel, email)
        {
            // base constructor already called at this point
        }

        public Appointment MakeAppointment()
        {
            throw new NotImplementedException();
        }

        public Appointment CancelAppointment()
        {
            throw new NotImplementedException();
        }

        public Appointment ChangeAppointmentDate(DateTime newDate)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsCalendar()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetPastAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
