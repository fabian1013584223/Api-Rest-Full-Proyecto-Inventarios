using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record StockForCreationDTO

  (
  int CantidadReal,
  int CantidadIdeal,
  int CantidadAlarma,
  int CantidadMinima,
  DateTime FechaIngreso,
 IEnumerable<ProductoForCreationDTO>? Productos);
}