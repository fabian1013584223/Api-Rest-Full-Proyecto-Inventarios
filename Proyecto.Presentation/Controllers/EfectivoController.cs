//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;
//using Service.Contracts;
//using Shared.DataTransferObjects;

//namespace StockProductos.Presentation.Controllers
//{
//    [Route("api/metodoPagos/{MetodoPagoId}/efectivos")]
//    [ApiController]
//    public class EfectivoController : ControllerBase
//    {
//        private readonly IServiceManager _service;

//        public EfectivoController(IServiceManager service) => _service = service;

//        [HttpGet]
//        public async Task<IActionResult> GetEfectivosForMetodoPagoAsync(Guid MetodoPagoId)
//        {
//            var efectivos = await _service.EfectivoService.GetAllEfectivoAsync(MetodoPagoId, trackChanges: false);
//            return Ok(efectivos);
//        }

//        [HttpGet("{EfectivoId:guid}", Name = "GetEfectivoForMetodoPago")]
//        public async Task<IActionResult> GetEfectivoForMetodoPagoAsync(Guid MetodoPagoId, Guid EfectivoId)
//        {
//            var efectivo = await _service.EfectivoService.GetEfectivoByIdAsync(MetodoPagoId, EfectivoId, trackChanges: false);
//            return Ok(efectivo);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateEfectivoForMetodoPagoAsync
//            (Guid MetodoPagoId, [FromBody] EfectivoForCreationDTO efectivo)
//        {
//            if (efectivo is null)
//                return BadRequest("EfectivoForCreationDTO object is null");
//            if (!ModelState.IsValid)
//                return UnprocessableEntity(ModelState);

//            var efectivoToReturn = await _service.EfectivoService.CreateEfectivoForMetodoPagoAsync(MetodoPagoId, efectivo, trackChanges: false);

//            return CreatedAtRoute("GetEfectivoForMetodoPago", new { MetodoPagoId, id = efectivoToReturn.EfectivoId },
//                efectivoToReturn);
//        }

//        [HttpDelete("{id:guid}")]
//        public IActionResult DeleteEfectivoForMetodoPago(Guid MetodoPagoId, Guid id)
//        {
//            _service.EfectivoService.DeleteEfectivoForMetodoPagoAsync(MetodoPagoId, id, trackChanges: false);

//            return NoContent();
//        }

//        [HttpPut("{id:guid}")]
//        public async Task<IActionResult> UpdateEfectivoForMetodoPagoAsync(Guid MetodoPagoId, Guid id,
//        [FromBody] EfectivoForUpdateDTO efectivo)
//        {
//            if (efectivo is null)
//                return BadRequest("EfectivoForUpdateDTO object is null");
//            if (!ModelState.IsValid)
//                return UnprocessableEntity(ModelState);

//            await _service.EfectivoService.UpdateEfectivoForMetodoPagoAsync(MetodoPagoId, id, efectivo,
//                compTrackChanges: false, empTrackChanges: true);

//            return NoContent();
//        }


//        [HttpPatch("{id:guid}")]
//        public async Task<IActionResult> PartiallyUpdateEfectivoForMetodoPago(Guid MetodoPagoId, Guid EfectivoId,
//        [FromBody] JsonPatchDocument<EfectivoForUpdateDTO> patchDoc)
//        {
//            if (patchDoc is null)
//                return BadRequest("patchDoc object sent from client is null.");

//            var result = await _service.EfectivoService.GetEfectivoForPatchAsync(MetodoPagoId, EfectivoId,
//                compTrackChanges: false, empTrackChanges: true);

//            patchDoc.ApplyTo(result.efectivoToPatch, ModelState);

//            TryValidateModel(result.efectivoToPatch);

//            if (!ModelState.IsValid)
//                return UnprocessableEntity(ModelState);

//            await _service.EfectivoService.SaveChangesForPatchAsync(result.efectivoToPatch, result.efectivoEntity);

//            return NoContent();
//        }
//    }
//}

