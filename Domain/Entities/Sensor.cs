
using System;

namespace EnergySaverAPI.Domain.Entities
{
    public class Sensor
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public Guid PosteId { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
