using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEfectivoRepository
    {
        //IEnumerable<Precio> GetAllPrecios(Guid PId, bool trackChanges);
        //Precio GetPrecioById(Guid PId, Guid PrecioId, bool trackChanges);
        //void CreatePrecioForProducto(Guid PId, Precio precio);
        //void DeletePrecio(Precio precio);

        //Metodo de pago padre de la entidad efectivo
        Task<IEnumerable<Efectivo>> GetAllEfectivoAsync(Guid MetodoPagoId, bool trackChanges);
        Task<Efectivo> GetEfectivoByIdAsync(Guid MetodoPagoId, Guid EfectivoId, bool trackChanges);
        void CreateEfectivoForMetodoPago(Guid MetodoPagoId, Efectivo efectivo);
        void DeleteEfectivo(Efectivo efectivo);

    }
}