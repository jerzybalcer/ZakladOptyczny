using ZakladOptyczny.Models.Utilities;

namespace ZakladOptyczny.Models.Interfaces
{
    public interface IAppointmentManager
    {
        public Appointment MakeAppointment();

        public Appointment ChangeAppointmentDate(DateTime newDate);

        public Appointment CancelAppointment();
    }
}
