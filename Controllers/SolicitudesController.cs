using hogwartsApi.Models;
using hogwartsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace hogwartsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly SolicitudService _solicitudService;

        public SolicitudesController(SolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        [HttpGet]
        public ActionResult<List<Solicitud>> GetSolicitudes() =>
            _solicitudService.GetSolicitudes();

        [HttpGet("{id:length(24)}", Name = "GetSolicitud")]
        public ActionResult<Solicitud> GetSolicitud(string id)
        {
            var solicitud = _solicitudService.GetSolicitud(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return solicitud;
        }

        [HttpPost]
        public ActionResult<Solicitud> Create(Solicitud solicitud)
        {
            _solicitudService.Create(solicitud);

            return CreatedAtRoute("GetSolicitud", new {id = solicitud.Id}, solicitud);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Solicitud solicitudIn)
        {
            var solicitud = _solicitudService.GetSolicitud(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            _solicitudService.Update(id, solicitudIn);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var solicitud = _solicitudService.GetSolicitud(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            _solicitudService.Remove(solicitud.Id);

            return Ok();
        }
    }
}
