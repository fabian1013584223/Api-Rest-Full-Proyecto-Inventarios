using Entities.Models;
using Shared.DataTransferObjects;
using AutoMapper;

namespace APIRestProyecto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            

            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.IdCategoria));
            CreateMap<CategoriaForCreationDTO, Categoria>();
            CreateMap<CategoriaForUpdateDTO, Categoria>();

            //Stock
            CreateMap<Stock, StockDTO>()
            .ForMember(DTO => DTO.StockId, opt => opt.MapFrom(src => src.StockId));

            CreateMap<StockForCreationDTO, Stock>();
            CreateMap<StockForUpdateDTO, Stock>();

            CreateMap<DetalleFacturaCliente, DetalleDto>();
            CreateMap<DetalleDto, DetalleFacturaCliente>();
            CreateMap<DetalleDto, DetalleFacturaCliente>();

           
            CreateMap<FacturaProveedor, FacturaProveedorDto>()
                .ForMember(dest => dest.FacturaCompraId, opt => opt.MapFrom(src => src.FacturaCompraId));
            CreateMap<FacturaProveedorDto, FacturaProveedor>();
            CreateMap<FacturaProveedorDto, FacturaProveedor>().ReverseMap();

            CreateMap<FacturaCliente, FacturaDto>()
                .ForMember(dest => dest.FacturaVentaId, opt => opt.MapFrom(src => src.FacturaVentaId));
            CreateMap<FacturaDto, FacturaCliente>();
            CreateMap<FacturaDto, FacturaCliente>().ReverseMap();

            

            CreateMap<Precios, PrecioDTO>()
                .ForMember(dest => dest.IdHistoricoPrecios, opt => opt.MapFrom(src => src.IdHistoricoPrecios));
            CreateMap<PrecioDTO, Precios>();
            CreateMap<PrecioDTO, Precios>().ReverseMap();

            //CreateMap<MetodoPago, MetodoPagoDTO>()
            //    .ForMember(dest => dest.IdMetodoPago, opt => opt.MapFrom(src => src.IdMetodoPago));
            //CreateMap<MetodoPagoForCreationDTO, MetodoPago>();
            //CreateMap<MetodoPagoForUpdateDTO, MetodoPago>().ReverseMap();

           

            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId));
            CreateMap<ProductoForCreationDTO, Producto>();
            CreateMap<ProductoForUpdateDTO, Producto>().ReverseMap();

            CreateMap<Proveedor, ProveedorDto>()
                .ForMember(dest => dest.IdProveedor, opt => opt.MapFrom(src => src.IdProveedor));
            CreateMap<ProveedorForCreationDto, Proveedor>();
            CreateMap<ProveedorForUpdateDto, Proveedor>();

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario));
            CreateMap<UsuarioForCreationDto, Usuario>();
            CreateMap<UsuarioForUpdateDto, Usuario>();
        }
    }
}
