using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEntidadBancariaRepository
    {
        //IEnumerable<Precio> GetAllPrecios(Guid PId, bool trackChanges);
        //Precio GetPrecioById(Guid PId, Guid PrecioId, bool trackChanges);
        //void CreatePrecioForProducto(Guid PId, Precio precio);
        //void DeletePrecio(Precio precio);

        //Metodo de pago padre de la EntidadBancaria
        Task<IEnumerable<EntidadBancaria>> GetAllEntidadBancariaAsync(Guid MetodoPagoId, bool trackChanges);
        Task<EntidadBancaria> GetEntidadBancariaByIdAsync(Guid MetodoPagoId, Guid EntidadBancariaId, bool trackChanges);
        void CreateEntidadBancariaForMetodoPago(Guid MetodoPagoId, EntidadBancaria entidadBancaria);
        void DeleteEntidadBancaria(EntidadBancaria entidadBancaria);
    }
}