using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumoHistoricoController : ControllerBase
    {
        private readonly IConsumoHistoricoService _consumoHistoricoService;

        public ConsumoHistoricoController(IConsumoHistoricoService consumoHistoricoService)
        {
            _consumoHistoricoService = consumoHistoricoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConsumoHistorico>> GetAll()
        {
            return Ok(_consumoHistoricoService.GetAllConsumos());
        }

        [HttpGet("{id}")]
        public ActionResult<ConsumoHistorico> GetById(Guid id)
        {
            var consumo = _consumoHistoricoService.GetConsumoById(id);
            if (consumo == null)
            {
                return NotFound();
            }
            return Ok(consumo);
        }

        [HttpGet("Poste/{posteId}")]
        public ActionResult<IEnumerable<ConsumoHistorico>> GetByPosteId(Guid posteId)
        {
            return Ok(_consumoHistoricoService.GetConsumosByPosteId(posteId));
        }

        [HttpPost]
        public ActionResult Add(ConsumoHistorico consumoHistorico)
        {
            _consumoHistoricoService.AddConsumo(consumoHistorico);
            return CreatedAtAction(nameof(GetById), new { id = consumoHistorico.Id }, consumoHistorico);
        }
    }
}
