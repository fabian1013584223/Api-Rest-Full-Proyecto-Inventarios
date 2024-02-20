//using Entities.Models;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;
//using Service.Contracts;
//using Shared.DataTransferObjects;

//namespace StockProductos.Presentation.Controllers
//{
//    [Route("api/metodoPagos/{MetodoPagoId}/entidadBancarias")]
//    [ApiController]
//    public class EntidadBancariaController : ControllerBase
//    {
//        private readonly IServiceManager _service;

//        public EntidadBancariaController(IServiceManager service) => _service = service;

//        [HttpGet]
//        public async Task<IActionResult> GetEntidadBancariasForMetodoPagoAsync(Guid MetodoPagoId)
//        {
//            var entidadBancarias = await _service.EntidadBancariaService.GetAllEntidadBancariaAsync(MetodoPagoId, trackChanges: false);
//            return Ok(entidadBancarias);
//        }

//        [HttpGet("{EntidadBancariaId:guid}", Name = "GetEntidadBancariaForMetodoPago")]
//        public async Task<IActionResult> GetEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, Guid EntidadBancariaId)
//        {
//            var entidadBancaria = await _service.EntidadBancariaService.GetEntidadBancariaByIdAsync(MetodoPagoId, EntidadBancariaId, trackChanges: false);
//            return Ok(entidadBancaria);
//        }//

//        [HttpPost]
//        public async Task<IActionResult> CreateEntidadBancariaForMetodoPagoAsync
//            (Guid MetodoPagoId, [FromBody] EntidadBancariaForCreationDTO entidadBancaria)
//        {
//            if (entidadBancaria is null)
//                return BadRequest("EntidadBancariaForCreationDTO object is null");
//            if (!ModelState.IsValid)
//                return UnprocessableEntity(ModelState);

//            var entidadBancariaToReturn = await _service.EntidadBancariaService.CreateEntidadBancariaForMetodoPagoAsync(MetodoPagoId, entidadBancaria, trackChanges: false);

//            return CreatedAtRoute("GetEntidadBancariaForMetodoPago", new { MetodoPagoId, id = entidadBancariaToReturn.EntidadBancariaId },
//                entidadBancariaToReturn);
//        }//

//        [HttpDelete("{id:guid}")]
//        public IActionResult DeleteEntidadBancariaForMetodoPago(Guid MetodoPagoId, Guid id)
//        {
//            _service.EntidadBancariaService.DeleteEntidadBancariaForMetodoPagoAsync(MetodoPagoId, id, trackChanges: false);

//            return NoContent();
//        }//

//        [HttpPut("{id:guid}")]
//        public async Task<IActionResult> UpdateEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, Guid id,
//        [FromBody] EntidadBancariaForUpdateDTO entidadBancaria)
//        {
//            if (entidadBancaria is null)
//                return BadRequest("EntidadBancariaForUpdateDTO object is null");
//            if (!ModelState.IsValid)
//                return UnprocessableEntity(ModelState);

//            await _service.EntidadBancariaService.UpdateEntidadBancariaForMetodoPagoAsync(MetodoPagoId, id, entidadBancaria,
//                compTrackChanges: false, empTrackChanges: true);

//            return NoContent();
//        }
//        //

//        [HttpPatch("{id:guid}")]
//        public async Task<IActionResult> PartiallyUpdateEntidadBancariaForMetodoPago(Guid MetodoPagoId, Guid EntidadBancariaId,
//        [FromBody] JsonPatchDocument<EntidadBancariaForUpdateDTO> patchDoc)
//        {
//            if (patchDoc is null)
//                return BadRequest("patchDoc object sent from client is null.");

//            var result = await _service.EntidadBancariaService.GetEntidadBancariaForPatchAsync(MetodoPagoId, EntidadBancariaId,
//                compTrackChanges: false, empTrackChanges: true);

//            patchDoc.ApplyTo(result.entidadBancariaToPatch, ModelState);

//            TryValidateModel(result.entidadBancariaToPatch);

//            if (!ModelState.IsValid)
//                return UnprocessableEntity(ModelState);

//            await _service.EntidadBancariaService.SaveChangesForPatchAsync(result.entidadBancariaToPatch, result.entidadBancariaEntity);

//            return NoContent();
//        }
//    }
//}




