
using System;

namespace EnergySaverAPI.Domain.Entities
{
    public class ConsumoHistorico
    {
        public Guid Id { get; set; }
        public Guid PosteId { get; set; }
        public DateTime DataRegistro { get; set; }
        public double Consumo { get; set; }
    }
}
