using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Interfaces
{
    public interface ICalendarManager
    {
        public List<Appointment> GetAppointmentsCalendar();

        public List<Appointment> GetPastAppointments();
    }
}
