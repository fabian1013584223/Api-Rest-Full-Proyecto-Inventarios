using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
       
        private readonly Lazy<ICategoriaService> _categoriaService;
        private readonly Lazy<IDetFacturaProveedorService> _detFacturaCompraService;
        private readonly Lazy<IDetFacturaClienteService> _detFacturaVentaService;
         private readonly Lazy<IFacturaProveedorService> _facturaCompraService;
        private readonly Lazy<IFacturaClienteService> _facturaVentaService;
        private readonly Lazy<PreciosService> _preciosService;
        private readonly Lazy<IMetodoPagoService> _metodoPagoService;
        private readonly Lazy<IProductoService> _productoService;
        private readonly Lazy<IProveedorService> _proveedorService;
        private readonly Lazy<IUsuarioService> _usuarioService;
        private readonly Lazy<IClienteService> _clienteService;
        private readonly Lazy<IStockService> _stockService;


        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger
            , IMapper mapper)
        {
            

            _categoriaService = new Lazy<ICategoriaService>(() =>
            new CategoriaService(repositoryManager, logger, mapper));



            _detFacturaCompraService = new Lazy<IDetFacturaProveedorService>(() =>
            new DetProveedorService(repositoryManager, logger, mapper));

            _detFacturaVentaService = new Lazy<IDetFacturaClienteService>(() =>
            new DetFacturaClienteService(repositoryManager, logger, mapper));

           

            _facturaCompraService = new Lazy<IFacturaProveedorService>(() =>
            new FacturaProveedorService(repositoryManager, logger, mapper));

            _facturaVentaService = new Lazy<IFacturaClienteService>(() =>
            new FacturaClienteService(repositoryManager, logger, mapper));

            _preciosService = new Lazy<PreciosService>(() =>
            new PreciosService(repositoryManager, logger, mapper));

            _metodoPagoService = new Lazy<IMetodoPagoService>(() =>
            new MetodoPagoService(repositoryManager, logger, mapper));


            _productoService = new Lazy<IProductoService>(() =>
            new ProductoService(repositoryManager, logger, mapper));

            _proveedorService = new Lazy<IProveedorService>(() =>
            new ProveedorService(repositoryManager, logger, mapper));

            _usuarioService = new Lazy<IUsuarioService>(() =>
            new UsuarioService(repositoryManager, logger, mapper));

            _clienteService = new Lazy<IClienteService>(() =>
            new ClienteService(repositoryManager, logger, mapper));

            _stockService = new Lazy<IStockService>(() =>
          new StockService(repositoryManager, logger, mapper));
        }
        
        public ICategoriaService CategoriaService => _categoriaService.Value;

        
        public IDetFacturaProveedorService DetFacturaCompraService => _detFacturaCompraService.Value;

        public IDetFacturaClienteService DetFacturaVentaService =>_detFacturaVentaService.Value;

        

        public IFacturaProveedorService FacturaCompraService => _facturaCompraService.Value;

        public IFacturaClienteService FacturaVentaService => _facturaVentaService.Value;

        public IPreciosService PreciosService => _preciosService.Value;

        public IMetodoPagoService MetodoPagoService => _metodoPagoService.Value;

       
        public IProductoService ProductoService => _productoService.Value;

        public IProveedorService ProveedorService => _proveedorService.Value;

        public IUsuarioService UsuarioService => _usuarioService.Value;
        public IClienteService ClienteService => _clienteService.Value;

        public IStockService StockService => _stockService.Value;


    }
}
