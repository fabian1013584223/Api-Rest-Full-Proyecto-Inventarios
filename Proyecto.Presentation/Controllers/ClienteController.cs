using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proyect.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Presentation.Controllers
{

    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ClienteController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _service.ClienteService.GetAllCompanies(trackChanges: false);

            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "ClienteById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _service.ClienteService.GetCompany(id, trackChanges: false);
            return Ok(company);
        }

        [HttpGet("collection/({ids})", Name = "clienteCollection")]
        public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = _service.ClienteService.GetByIds(ids, trackChanges: false);

            return Ok(companies);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] ClienteForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("Fatura ForCreationDto object is null");

            var employeeToReturn = _service.ClienteService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetFacturaForProveedor", new { companyId, id = employeeToReturn.ClienteId },
                employeeToReturn);
        }


        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid id)
        {
            _service.ClienteService.DeleteEmployeeForCompany(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeForCompany(Guid id, [FromBody] ProveedorForUpdateDto company)
        {
            if (company is null)
                return BadRequest("CompanyForUpdateDto object is null");

            _service.ClienteService.UpdateEmployeeForCompany(id, trackChanges: false);

            return NoContent();
        }


    }
}


