using ZakladOptyczny.Models.Interfaces;
using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Actors
{
    public class Receptionist : User, IAppointmentManager, ICalendarManager
    {
        public Receptionist(string name, string surname, string pesel, string email, int dbId) : base(name, surname, pesel, email, dbId)
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

        public Appointment ChangeAppointmentAttendedState(Appointment appointment, bool isAttended)
        {
            appointment.IsAttended = isAttended;
            return appointment;
        }

        public List<User> SearchUsers(string searchPhrase)
        {
            throw new NotImplementedException();
        }
    }
}
