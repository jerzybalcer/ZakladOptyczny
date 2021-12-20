using ZakladOptyczny.Models.Interfaces;
using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Actors
{
    public class Patient : User, IAppointmentManager, ICalendarManager
    {
        public Patient(string name, string surname, string pesel, string email, int dbId) : base(name, surname, pesel, email, dbId)
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

        public void GetAppointmentsCalendar()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetPastAppointments()
        {
            throw new NotImplementedException();
        }
    }
}
