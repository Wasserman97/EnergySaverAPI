using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Domain.Entities;

namespace EnergySaverAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensoresController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensoresController(ISensorService sensorService)
        {
            _sensorService = sensorService ?? throw new ArgumentNullException(nameof(sensorService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sensor>> GetAll()
        {
            return Ok(_sensorService.GetAllSensores());
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Sensor> GetById(Guid id)
        {
            var sensor = _sensorService.GetSensorById(id);
            if (sensor == null)
            {
                return NotFound();
            }
            return Ok(sensor);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Sensor sensor)
        {
            if (sensor == null)
            {
                return BadRequest("Sensor data is null.");
            }
            _sensorService.AddSensor(sensor);
            return CreatedAtAction(nameof(GetById), new { id = sensor.Id }, sensor);
        }

        [HttpPut("{id:guid}")]
        public ActionResult Update(Guid id, [FromBody] Sensor sensor)
        {
            if (id != sensor.Id)
            {
                return BadRequest("ID mismatch.");
            }

            _sensorService.UpdateSensor(sensor);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            _sensorService.DeleteSensor(id);
            return NoContent();
        }
    }
}
