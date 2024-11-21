using System;
using System.Collections.Generic;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Application.Interfaces
{
    public interface IConsumoHistoricoService
    {
        IEnumerable<ConsumoHistorico> GetAllConsumos();
        ConsumoHistorico GetConsumoById(Guid id);
        IEnumerable<ConsumoHistorico> GetConsumosByPosteId(Guid posteId);
        void AddConsumo(ConsumoHistorico consumoHistorico);
    }
}
