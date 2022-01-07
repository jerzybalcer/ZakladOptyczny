using ZakladOptyczny.Models.Actors;

namespace ZakladOptyczny.Models.Utilities.Database.Appointments
{
    public class AppointmentManager : IAppointmentManager
    {
        private readonly DatabaseContext _db;

        public AppointmentManager(DatabaseContext dbContext)
        {
            _db = dbContext;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _db.Appointments.ToList();
        }

        public List<Appointment> GetUserAppointments(User user)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Appointment MakeAppointment(DateTime date, User user)
        {
            Appointment appointment = new Appointment
            {
                Date = date,
                User = user
            };

            _db.Appointments.Add(appointment);
            _db.SaveChanges();

            return appointment;
        }

        public void CancelAppointment(Appointment appointment)
        {
            _db.Appointments.Remove(appointment);
            _db.SaveChanges();
        }

        public void UpdateAppointment(Appointment newAppointment)
        {
            // update
            _db.SaveChanges();
        }
    }
}
