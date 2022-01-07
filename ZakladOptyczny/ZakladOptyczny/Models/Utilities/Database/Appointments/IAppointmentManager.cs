using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities.Database.Appointments
{
    public interface IAppointmentManager
    {
        public List<Appointment> GetAllAppointments();

        public List<Appointment> GetUserAppointments(User user);

        public Appointment? GetAppointmentById(int id);

        public Appointment MakeAppointment(DateTime date, User user);

        public void CancelAppointment(Appointment appointment);

        public void UpdateAppointment(Appointment appointment);
    }
}
