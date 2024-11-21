
using System;
using System.Collections.Generic;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Application.Interfaces
{
    public interface IPosteService
    {
        IEnumerable<Poste> GetAllPostes();
        Poste GetPosteById(Guid id);
        void AddPoste(Poste poste);
        void UpdatePoste(Poste poste);
        void DeletePoste(Guid id);
    }
}
