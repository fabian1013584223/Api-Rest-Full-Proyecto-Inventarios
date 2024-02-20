using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
namespace Service;

internal sealed class ClienteService : IClienteService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ClienteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<ClienteDto> GetAllCompanies(bool trackChanges)
    {
        var companies = _repository.Cliente.GetAllCompanies(trackChanges);

        var companiesDto = _mapper.Map<IEnumerable<ClienteDto>>(companies);

        return companiesDto;
    }

    public ClienteDto GetCompany(Guid id, bool trackChanges)
    {
        var company = _repository.Cliente.GetCompany(id, trackChanges);
        if (company is null)
            throw new ProveedorNotFoundException(id);

        var companyDto = _mapper.Map<ClienteDto>(company);
        return companyDto;
    }

    public ClienteDto CreateEmployeeForCompany(Guid companyId, ClienteForCreationDto employeeForCreation, bool trackChanges)
    {
        var company = _repository.Cliente.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new ClienteNotFoundException(companyId);

        var employeeEntity = _mapper.Map<Cliente>(employeeForCreation);

        _repository.Cliente.CreateEmployeeForCompany(companyId, employeeEntity);
        _repository.Save();

        var employeeToReturn = _mapper.Map<ClienteDto>(employeeEntity);

        return employeeToReturn;
    }


    public void DeleteEmployeeForCompany(Guid id, bool trackChanges)
    {


        var employeeForCompany = _repository.Cliente.GetCompany(id, trackChanges);
        if (employeeForCompany is null)
            throw new ClienteNotFoundException(id);

        _repository.Cliente.DeleteEmployee(employeeForCompany);
        _repository.Save();
    }
    public void UpdateEmployeeForCompany(Guid id, bool trackChanges)
    {
        var companyEntity = _repository.Cliente.GetCompany(id, trackChanges);
        if (companyEntity is null)
            throw new ProveedorNotFoundException(id);

        _mapper.Map(id, companyEntity);
        _repository.Save();
    }




    public void SaveChangesForPatch(ClienteForUpdateDto employeeToPatch, Cliente employeeEntity)
    {
        _mapper.Map(employeeToPatch, employeeEntity);
        _repository.Save();
    }
    public IEnumerable<ClienteDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var companyEntities = _repository.Cliente.GetByIds(ids, trackChanges);
        if (ids.Count() != companyEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var companiesToReturn = _mapper.Map<IEnumerable<ClienteDto>>(companyEntities);

        return companiesToReturn;
    }

    
}


