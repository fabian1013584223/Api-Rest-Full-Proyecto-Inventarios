using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class DetFacturaClienteService : IDetFacturaClienteService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DetFacturaClienteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<DetalleDto> GetAllDetSaleBills(bool trackChanges)
        {
            var dFacturaVenta = _repository.DetFacturaCliente.GetAllDetSaleBills(trackChanges);
            var DFacturaVentaDTO = _mapper.Map<IEnumerable<DetalleDto>>(dFacturaVenta);

            return DFacturaVentaDTO;
        }

        public DetalleDto GetDetSaleBill(Guid Id, bool trackChanges)
        {
            var dFacturaVenta = _repository.DetFacturaCliente.GetDetSaleBill(Id, trackChanges);
            if(dFacturaVenta == null)
            {
                throw new DetalleFacturaVentaNotFoundException(Id);
            }

            var DFacturaVentaDTO = _mapper.Map<DetalleDto>(dFacturaVenta);
            return DFacturaVentaDTO;
        }
    }
}
