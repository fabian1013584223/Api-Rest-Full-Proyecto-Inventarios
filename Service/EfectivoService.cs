//using AutoMapper;
//using Contracts;
//using Entities.Exceptions;
//using Entities.Models;
//using Service.Contracts;
//using Shared.DataTransferObjects;

//namespace Service
//{
//    internal sealed class EfectivoService : IEfectivoService
//    {
//        private readonly IRepositoryManager _repository;
//        private readonly ILoggerManager _logger;
//        private readonly IMapper _mapper;

//        public EfectivoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
//        {
//            _repository = repository;
//            _logger = logger;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<EfectivoDTO>> GetAllEfectivoAsync(Guid MetodoPagoId, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var efectivosFromDb = await _repository.Efectivo.GetAllEfectivoAsync(MetodoPagoId, trackChanges);
//            var efectivosDTO = _mapper.Map<IEnumerable<EfectivoDTO>>(efectivosFromDb);
//            return efectivosDTO;
//        }//

//        public async Task<EfectivoDTO> GetEfectivoByIdAsync(Guid MetodoPagoId, Guid EfectivoId, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var efectivoDb = await _repository.Efectivo.GetEfectivoByIdAsync(MetodoPagoId, EfectivoId, trackChanges);
//            if (efectivoDb is null)
//                throw new EfectivoNotFoundException(EfectivoId);


//            var efectivo = _mapper.Map<EfectivoDTO>(efectivoDb);
//            return efectivo;
//        }

//        public async Task<EfectivoDTO> CreateEfectivoForMetodoPagoAsync(Guid MetodoPagoId, EfectivoForCreationDTO efectivoForCreation, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var efectivoEntity = _mapper.Map<Efectivo>(efectivoForCreation);
//            _repository.Efectivo.CreateEfectivoForMetodoPago(MetodoPagoId, efectivoEntity);
//            await _repository.SaveAsync();

//            var efectivoToReturn = _mapper.Map<EfectivoDTO>(efectivoEntity);
//            return efectivoToReturn;
//        }

//        public async Task DeleteEfectivoForMetodoPagoAsync(Guid MetodoPagoId, Guid EfectivoId, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//            {
//                throw new MetodoPagoNotFoundException(MetodoPagoId);
//            }

//            var efectivoForMetodoPago = await _repository.Efectivo.GetEfectivoByIdAsync(MetodoPagoId, EfectivoId, trackChanges);
//            if (efectivoForMetodoPago is null)
//            {
//                throw new EfectivoNotFoundException(EfectivoId);
//            }

//            _repository.Efectivo.DeleteEfectivo(efectivoForMetodoPago);
//            await _repository.SaveAsync();

//        }

//        public async Task UpdateEfectivoForMetodoPagoAsync(Guid MetodoPagoId, Guid EfectivoId, EfectivoForUpdateDTO efectivoForUpdate, bool compTrackChanges, bool empTrackChanches)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, compTrackChanges);
//            if (metodoPago is null)
//            {
//                throw new MetodoPagoNotFoundException(MetodoPagoId);
//            }

//            var efectivoEntity = await _repository.Efectivo.GetEfectivoByIdAsync(MetodoPagoId, EfectivoId, empTrackChanches);
//            if (efectivoEntity is null)
//            {
//                throw new EfectivoNotFoundException(EfectivoId);
//            }
//            _mapper.Map(efectivoForUpdate, efectivoEntity);
//            await _repository.SaveAsync();
//        }



//        //Patch
//        public async Task<(EfectivoForUpdateDTO efectivoToPatch, Efectivo efectivoEntity)> GetEfectivoForPatchAsync
//        (Guid MetodoPagoId, Guid EfectivoId, bool compTrackChanges, bool empTrackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, compTrackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var efectivoEntity = await _repository.Efectivo.GetEfectivoByIdAsync(MetodoPagoId, EfectivoId, empTrackChanges);
//            if (efectivoEntity is null)
//                throw new EfectivoNotFoundException(MetodoPagoId);

//            var efectivoToPatch = _mapper.Map<EfectivoForUpdateDTO>(efectivoEntity);

//            return (efectivoToPatch, efectivoEntity);
//        }

//        public async Task SaveChangesForPatchAsync(EfectivoForUpdateDTO efectivoToPatch, Efectivo efectivoEntity)
//        {
//            _mapper.Map(efectivoToPatch, efectivoEntity);
//            await _repository.SaveAsync();
//        }
//    }
//}


