using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
       
        ICategoriaRepository Categoria { get; }
        IDetFacturaProveedorRepository DetFacturaProveedor { get; }
        IDetFacturaClienteRepository DetFacturaCliente { get; }
        IFacturaProveedorRepository FacturaCompra { get; }
        IFacturaClienteRepository FacturaVenta { get; }
        IPreciosRepository HistoricoPrecios { get; }
        IMetodoPagoRepository MetodoPago { get; }
        IProductoRepository Producto { get; }
        IProveedorRepository Proveedor { get; }
        IUsuarioRepository Usuario { get; }
        IClienteRepository Cliente { get; }
        IStockRepository Stock { get; }

        void Save();
        Task SaveAsync();
    }
}
