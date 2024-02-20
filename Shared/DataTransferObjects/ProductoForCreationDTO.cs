using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProductoForCreationDTO
    (
         string Nombre,
        int Cantidad,
        float Precio,
        string Estado,
        string Lugar,
        Guid StockId,
        Guid IdCategoria
    );
}
