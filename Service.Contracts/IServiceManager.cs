using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        
        ICategoriaService CategoriaService { get; }
      

        IDetFacturaClienteService DetFacturaVentaService { get; }
        IFacturaProveedorService FacturaCompraService { get; }
        IFacturaClienteService FacturaVentaService { get;}
        IPreciosService PreciosService { get; }
        IMetodoPagoService MetodoPagoService { get; }
       IClienteService ClienteService { get; }
        IProductoService ProductoService { get; }
        IProveedorService ProveedorService { get; }
        IUsuarioService UsuarioService { get; }
        IStockService StockService { get; }
    }
}
