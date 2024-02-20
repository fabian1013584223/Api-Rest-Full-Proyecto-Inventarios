using Contracts;
using Entities.Models;

namespace Repository;

internal sealed class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
{
    public ClienteRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Cliente> GetAllCompanies(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Nombre)
            .ToList();

    public Cliente GetCompany(Guid companyId, bool trackChanges) =>
        FindByCondition(c => c.ClienteId.Equals(companyId), trackChanges)
        .SingleOrDefault();

    public void CreateEmployeeForCompany(Guid companyId, Cliente employee)
    {
        employee.UsuarioId = companyId;
        Create(employee);
    }
    public IEnumerable<Cliente> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.ClienteId), trackChanges)
        .ToList();
    public void DeleteEmployee(Cliente employee) => Delete(employee);
    public void CreateCompany(Cliente company) => Create(company);

}
