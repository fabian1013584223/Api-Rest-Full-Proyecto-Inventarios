using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

       private readonly Lazy<ICategoriaRepository> _categoriaRepository;
        private readonly Lazy<IDetFacturaProveedorRepository> _detFacturaCompraRepository;
        private readonly Lazy<IDetFacturaClienteRepository> _detFacturaVentaRepository;
         private readonly Lazy<IFacturaProveedorRepository> _facturaCompraRepository;
        private readonly Lazy<IFacturaClienteRepository> _facturaVentaRepository;
        private readonly Lazy<IPreciosRepository> _historicoPreciosRepository;
        private readonly Lazy<IMetodoPagoRepository> _metodoPagoRepository;
        private readonly Lazy<IProductoRepository> _productoRepository;
        private readonly Lazy<IProveedorRepository> _proveedorRepository;
        private readonly Lazy<IUsuarioRepository> _usuarioRepository;
        private readonly Lazy<IClienteRepository> _clienteRepository;
        private readonly Lazy<IStockRepository> _stockRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

 

            _categoriaRepository = new Lazy<ICategoriaRepository>(() =>
            new CategoriaRepository(repositoryContext));

            
            _detFacturaCompraRepository = new Lazy<IDetFacturaProveedorRepository>(() =>
            new DetalleFacturaProvedorRepository(repositoryContext));

            _detFacturaVentaRepository = new Lazy<IDetFacturaClienteRepository>(() =>
            new DetalleFacturaClienteRepository(repositoryContext));

            

            _facturaCompraRepository = new Lazy<IFacturaProveedorRepository>(() =>
            new FacturaProveedorRepository(repositoryContext));

            _facturaVentaRepository = new Lazy<IFacturaClienteRepository>(() =>
            new FacturaClienteRepository(repositoryContext));

            _historicoPreciosRepository = new Lazy<IPreciosRepository>(() =>
            new PreciosRepository(repositoryContext));

            //_metodoPagoRepository = new Lazy<IMetodoPagoRepository>(() =>
            //new MetodoPagoRepository(repositoryContext));

         

            _productoRepository = new Lazy<IProductoRepository>(() =>
            new ProductoRepository(repositoryContext));

            _proveedorRepository = new Lazy<IProveedorRepository>(() =>
            new ProveedorRepository(repositoryContext));

            _usuarioRepository = new Lazy<IUsuarioRepository>(() =>
            new UsuarioRepository(repositoryContext));

            _clienteRepository = new Lazy<IClienteRepository>(() =>
            new ClienteRepository(repositoryContext));
            _stockRepository = new Lazy<IStockRepository>(() =>
            new StockRepository(repositoryContext));
        }
       
        public ICategoriaRepository Categoria => _categoriaRepository.Value;
        
        public IDetFacturaProveedorRepository DetFacturaProveedor => _detFacturaCompraRepository.Value;
        public IDetFacturaClienteRepository DetFacturaCliente => _detFacturaVentaRepository.Value;

        public IFacturaProveedorRepository FacturaCompra => _facturaCompraRepository.Value;
        public IFacturaClienteRepository FacturaVenta => _facturaVentaRepository.Value;
        public IPreciosRepository HistoricoPrecios => _historicoPreciosRepository.Value;
        public IMetodoPagoRepository MetodoPago => _metodoPagoRepository.Value;
       
        public IProductoRepository Producto => _productoRepository.Value;
        public IProveedorRepository Proveedor => _proveedorRepository.Value;
        public IUsuarioRepository Usuario => _usuarioRepository.Value;
        public IClienteRepository Cliente => _clienteRepository.Value;
      

        public IStockRepository Stock => _stockRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
