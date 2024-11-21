using System;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Application.Interfaces
{
    public interface ISensorFactory
    {
        Sensor CreateSensor(string tipo, Guid posteId);
    }
}
