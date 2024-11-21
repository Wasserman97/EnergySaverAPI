
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostesController : ControllerBase
    {
        private readonly IPosteService _posteService;

        public PostesController(IPosteService posteService)
        {
            _posteService = posteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Poste>> GetAll()
        {
            return Ok(_posteService.GetAllPostes());
        }

        [HttpGet("{id}")]
        public ActionResult<Poste> GetById(Guid id)
        {
            var poste = _posteService.GetPosteById(id);
            if (poste == null)
            {
                return NotFound();
            }
            return Ok(poste);
        }

        [HttpPost]
        public ActionResult Add(Poste poste)
        {
            _posteService.AddPoste(poste);
            return CreatedAtAction(nameof(GetById), new { id = poste.Id }, poste);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, Poste poste)
        {
            if (id != poste.Id)
            {
                return BadRequest();
            }
            _posteService.UpdatePoste(poste);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _posteService.DeletePoste(id);
            return NoContent();
        }
    }
}
