using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IClienteService
{
    IEnumerable<ClienteDto> GetAllCompanies(bool trackChanges);
    ClienteDto GetCompany(Guid companyId, bool trackChanges);
    ClienteDto CreateEmployeeForCompany(Guid companyId, ClienteForCreationDto employeeForCreation, bool trackChanges);
    IEnumerable<ClienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteEmployeeForCompany(Guid id, bool trackChanges);
    void UpdateEmployeeForCompany(Guid id, bool trackChanges);
    
}
