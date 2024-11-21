
using System;
using System.Collections.Generic;
using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Domain.Entities;
using EnergySaverAPI.Infrastructure.Persistence;

namespace EnergySaverAPI.Application.Services
{
    public class PosteService : IPosteService
    {
        private readonly EnergySaverDbContext _context;

        public PosteService(EnergySaverDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Poste> GetAllPostes()
        {
            return _context.Postes;
        }

        public Poste GetPosteById(Guid id)
        {
            return _context.Postes.Find(id);
        }

        public void AddPoste(Poste poste)
        {
            _context.Postes.Add(poste);
            _context.SaveChanges();
        }

        public void UpdatePoste(Poste poste)
        {
            _context.Postes.Update(poste);
            _context.SaveChanges();
        }

        public void DeletePoste(Guid id)
        {
            var poste = _context.Postes.Find(id);
            if (poste != null)
            {
                _context.Postes.Remove(poste);
                _context.SaveChanges();
            }
        }
    }
}
