using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Proyect.Presentation.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace Proyect.Presentation.Controllers
{
    [Route("api/productos/{productoId}/historicoPrecios")]
    [ApiController]
    public class HistoricoPreciosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public HistoricoPreciosController(IServiceManager service) => _service = service;

        [HttpGet("/api/historicoPrecios")]
        public IActionResult GetAllPriceHistories()
        {
            var historicoPrecio = _service.PreciosService.GetAllPriceHistories(trackChanges: false);
            return Ok(historicoPrecio);
        }

        [HttpGet("/api/historicoPrecios/{Id:Guid}", Name = "GetPriceHistory")]
        public IActionResult GetPriceHistory(Guid Id)
        {
            var histPrecios = _service.PreciosService.GetPriceHistory(Id, trackChanges: false);
            return Ok(histPrecios);
        }

        [HttpGet]
        public IActionResult GetAllPriceHistoriesForProduct(Guid productoId)
        {
            var historicoPrecio = _service.PreciosService.GetAllPriceHistoriesForProduct(productoId, trackChanges: false);
            return Ok(historicoPrecio);
        }

        [HttpGet("{Id:guid}", Name = "GetPriceHistoryForProduct")]
        public IActionResult GetPriceHistoryForProduct(Guid productoId, Guid Id)
        {
            var histPrecios = _service.PreciosService.GetPriceHistoryForProduct(productoId, Id, trackChanges: false);
            return Ok(histPrecios);
        }


        [HttpPost]
        public IActionResult CreatePriceHistoryForProduct(Guid productoId, [FromBody] PrecioForCreationDTO historicoPrecio)
        {
            if (historicoPrecio is null)
            {
                return BadRequest("PriceHistoryForCreationDto object is null");
            }
            var histPreciosToReturn = _service.PreciosService.CreatePriceHistoryForProduct(productoId, historicoPrecio, trackChanges: false);

            return CreatedAtRoute("GetPriceHistoryForProduct", new { productoId, Id = histPreciosToReturn.IdHistoricoPrecios },
                histPreciosToReturn);
        }


        [HttpDelete("{Id:guid}")]
        public IActionResult DeletePriceHistoryForProduct(Guid productoId, Guid Id)
        {
            _service.PreciosService.DeletePriceHistoryForProduct(productoId, Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{Id:guid}")]
        public IActionResult UpdatePriceHistoryForProduct(Guid productoId, Guid Id, [FromBody] PrecioForUpdateDTO historicoPrecio)
        {
            if (historicoPrecio is null)
            {
                return BadRequest("PriceHistoryForUpdateDto object is null");
            }

            _service.PreciosService.UpdatePriceHistoryForProduct(productoId, Id, historicoPrecio, productoTrackChanges: false, histPreciosTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{Id:guid}")]
        public IActionResult PartiallyUpdateHistoricoPreciosForProveedor(Guid productoId, Guid Id,
            [FromBody] JsonPatchDocument<PrecioForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.PreciosService.GetHistoricoPreciosForPatch(productoId, Id, productoTrackChanges: false, histPreciosTrackChanges: true);
            patchDoc.ApplyTo(result.histPreciosToPatch);

            _service.PreciosService.SaveChangesForPatch(result.histPreciosToPatch, result.histPreciosEntity);

            return NoContent();
        }
    }
}
