﻿using Microsoft.EntityFrameworkCore;
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
            return _db.Appointments.AsNoTracking().Include("User").ToList();
        }

        public List<Appointment> GetUserAppointments(User user)
        {
            return _db.Appointments.AsNoTracking().Include("User").Where(a => a.User == user).ToList();
        }

        public Appointment? GetAppointmentById(int id)
        {
            return _db.Appointments.AsNoTracking().Include("User").FirstOrDefault(a => a.AppointmentId == id);
        }

        public Appointment MakeAppointment(DateTime date, User user)
        {
            Appointment appointment = new Appointment
            {
                Date = date,
                User = user,
                UserId = user.UserId
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

        public void UpdateAppointment(Appointment appointment)
        {
            _db.Appointments.Update(appointment);
            _db.SaveChanges();
        }
    }
}
