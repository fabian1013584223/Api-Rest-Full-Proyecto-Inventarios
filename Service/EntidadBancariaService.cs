//using AutoMapper;
//using Contracts;
//using Entities.Exceptions;
//using Entities.Models;
//using Service.Contracts;
//using Shared.DataTransferObjects;

//namespace Service
//{
//    internal sealed class EntidadBancariaService : IEntidadBancariaService
//    {
//        private readonly IRepositoryManager _repository;
//        private readonly ILoggerManager _logger;
//        private readonly IMapper _mapper;

//        public EntidadBancariaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
//        {
//            _repository = repository;
//            _logger = logger;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<EntidadBancariaDTO>> GetAllEntidadBancariaAsync(Guid MetodoPagoId, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var entidadBancariasFromDb = await _repository.EntidadBancaria.GetAllEntidadBancariaAsync(MetodoPagoId, trackChanges);
//            var entidadBancariasDTO = _mapper.Map<IEnumerable<EntidadBancariaDTO>>(entidadBancariasFromDb);
//            return entidadBancariasDTO;
//        }//

//        public async Task<EntidadBancariaDTO> GetEntidadBancariaByIdAsync(Guid MetodoPagoId, Guid EntidadBancariaId, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var entidadBancariaDb = await _repository.EntidadBancaria.GetEntidadBancariaByIdAsync(MetodoPagoId, EntidadBancariaId, trackChanges);
//            if (entidadBancariaDb is null)
//                throw new EntidadBancariaNotFoundException(EntidadBancariaId);


//            var entidadBancaria = _mapper.Map<EntidadBancariaDTO>(entidadBancariaDb);
//            return entidadBancaria;
//        }

//        public async Task<EntidadBancariaDTO> CreateEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, EntidadBancariaForCreationDTO entidadBancariaForCreation, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var entidadBancariaEntity = _mapper.Map<EntidadBancaria>(entidadBancariaForCreation);
//            _repository.EntidadBancaria.CreateEntidadBancariaForMetodoPago(MetodoPagoId, entidadBancariaEntity);
//            await _repository.SaveAsync();

//            var entidadBancariaToReturn = _mapper.Map<EntidadBancariaDTO>(entidadBancariaEntity);
//            return entidadBancariaToReturn;
//        }

//        public async Task DeleteEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, Guid EntidadBancariaId, bool trackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, trackChanges);
//            if (metodoPago is null)
//            {
//                throw new MetodoPagoNotFoundException(MetodoPagoId);
//            }

//            var entidadBancariaForMetodoPago = await _repository.EntidadBancaria.GetEntidadBancariaByIdAsync(MetodoPagoId, EntidadBancariaId, trackChanges);
//            if (entidadBancariaForMetodoPago is null)
//            {
//                throw new EntidadBancariaNotFoundException(EntidadBancariaId);
//            }

//            _repository.EntidadBancaria.DeleteEntidadBancaria(entidadBancariaForMetodoPago);
//            await _repository.SaveAsync();

//        }

//        public async Task UpdateEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, Guid EntidadBancariaId, EntidadBancariaForUpdateDTO entidadBancariaForUpdate, bool compTrackChanges, bool empTrackChanches)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, compTrackChanges);
//            if (metodoPago is null)
//            {
//                throw new MetodoPagoNotFoundException(MetodoPagoId);
//            }

//            var entidadBancariaEntity = await _repository.EntidadBancaria.GetEntidadBancariaByIdAsync(MetodoPagoId, EntidadBancariaId, empTrackChanches);
//            if (entidadBancariaEntity is null)
//            {
//                throw new EntidadBancariaNotFoundException(EntidadBancariaId);
//            }
//            _mapper.Map(entidadBancariaForUpdate, entidadBancariaEntity);
//            await _repository.SaveAsync();
//        }



//        //Patch
//        public async Task<(EntidadBancariaForUpdateDTO entidadBancariaToPatch, EntidadBancaria entidadBancariaEntity)> GetEntidadBancariaForPatchAsync
//        (Guid MetodoPagoId, Guid EntidadBancariaId, bool compTrackChanges, bool empTrackChanges)
//        {
//            var metodoPago = await _repository.MetodoPago.GetMetodoPagoByIdAsync(MetodoPagoId, compTrackChanges);
//            if (metodoPago is null)
//                throw new MetodoPagoNotFoundException(MetodoPagoId);

//            var entidadBancariaEntity = await _repository.EntidadBancaria.GetEntidadBancariaByIdAsync(MetodoPagoId, EntidadBancariaId, empTrackChanges);
//            if (entidadBancariaEntity is null)
//                throw new EntidadBancariaNotFoundException(MetodoPagoId);

//            var entidadBancariaToPatch = _mapper.Map<EntidadBancariaForUpdateDTO>(entidadBancariaEntity);

//            return (entidadBancariaToPatch, entidadBancariaEntity);
//        }

//        public async Task SaveChangesForPatchAsync(EntidadBancariaForUpdateDTO entidadBancariaToPatch, EntidadBancaria entidadBancariaEntity)
//        {
//            _mapper.Map(entidadBancariaToPatch, entidadBancariaEntity);
//            await _repository.SaveAsync();
//        }
//    }
//}


