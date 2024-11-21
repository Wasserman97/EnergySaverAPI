using System;
using System.Collections.Generic;
using System.Linq;
using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Domain.Entities;
using EnergySaverAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EnergySaverAPI.Application.Services
{
    public class SensorService : ISensorService
    {
        private readonly EnergySaverDbContext _context;

        public SensorService(EnergySaverDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sensor> GetAllSensores()
        {
            return _context.Sensores.AsNoTracking().ToList();
        }

        public Sensor GetSensorById(Guid id)
        {
            return _context.Sensores.AsNoTracking().FirstOrDefault(s => s.Id == id);
        }

        public void AddSensor(Sensor sensor)
        {
            if (sensor == null)
                throw new ArgumentNullException(nameof(sensor), "O objeto Sensor não pode ser nulo.");

            _context.Sensores.Add(sensor);
            _context.SaveChanges();
        }

        public void UpdateSensor(Sensor sensor)
        {
            if (sensor == null)
                throw new ArgumentNullException(nameof(sensor), "O objeto Sensor não pode ser nulo.");

            _context.Sensores.Update(sensor);
            _context.SaveChanges();
        }

        public void DeleteSensor(Guid id)
        {
            var sensor = _context.Sensores.Find(id);
            if (sensor == null)
                throw new KeyNotFoundException("Sensor não encontrado para exclusão.");

            _context.Sensores.Remove(sensor);
            _context.SaveChanges();
        }
    }
}
