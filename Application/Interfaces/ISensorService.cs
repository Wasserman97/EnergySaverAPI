using System;
using System.Collections.Generic;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Application.Interfaces
{
    public interface ISensorService
    {
        IEnumerable<Sensor> GetAllSensores();
        Sensor GetSensorById(Guid id);
        void AddSensor(Sensor sensor);
        void UpdateSensor(Sensor sensor);
        void DeleteSensor(Guid id);
    }
}
