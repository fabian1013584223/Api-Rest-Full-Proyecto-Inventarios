using Entities.Models;

namespace Contracts;

public interface IClienteRepository
{
    IEnumerable<Cliente> GetAllCompanies(bool trackChanges);
    Cliente GetCompany(Guid companyId, bool trackChanges);
    IEnumerable<Cliente> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void CreateEmployeeForCompany(Guid companyId, Cliente employee);
    void DeleteEmployee(Cliente employee);
}
