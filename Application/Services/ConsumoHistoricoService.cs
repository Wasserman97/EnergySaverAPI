using System;
using System.Collections.Generic;
using System.Linq;
using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Domain.Entities;
using EnergySaverAPI.Infrastructure.Persistence;

namespace EnergySaverAPI.Application.Services
{
    public class ConsumoHistoricoService : IConsumoHistoricoService
    {
        private readonly EnergySaverDbContext _context;

        public ConsumoHistoricoService(EnergySaverDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ConsumoHistorico> GetAllConsumos()
        {
            return _context.ConsumoHistoricos.ToList();
        }

        public ConsumoHistorico GetConsumoById(Guid id)
        {
            return _context.ConsumoHistoricos.Find(id);
        }

        public IEnumerable<ConsumoHistorico> GetConsumosByPosteId(Guid posteId)
        {
            return _context.ConsumoHistoricos.Where(c => c.PosteId == posteId).ToList();
        }

        public void AddConsumo(ConsumoHistorico consumoHistorico)
        {
            _context.ConsumoHistoricos.Add(consumoHistorico);
            _context.SaveChanges();
        }
    }
}
