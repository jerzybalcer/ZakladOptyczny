using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Interfaces
{
    public interface ICalendarManager
    {
        public void GetAppointmentsCalendar();

        public List<Appointment> GetPastAppointments();
    }
}
