using System;
using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Application.Factories
{
    public class SensorFactory : ISensorFactory
    {
        public Sensor CreateSensor(string tipo, Guid posteId)
        {
            return new Sensor
            {
                Id = Guid.NewGuid(),
                Tipo = tipo,
                PosteId = posteId,
                UltimaAtualizacao = DateTime.UtcNow
            };
        }
    }
}
