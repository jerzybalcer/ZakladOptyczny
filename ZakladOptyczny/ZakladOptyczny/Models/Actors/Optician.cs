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
