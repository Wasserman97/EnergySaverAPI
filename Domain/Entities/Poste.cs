
using System;

namespace EnergySaverAPI.Domain.Entities
{
    public class Poste
    {
        public Guid Id { get; set; }
        public string Localizacao { get; set; }
        public double ConsumoEnergetico { get; set; }
        public bool Ativo { get; set; }
    }
}
