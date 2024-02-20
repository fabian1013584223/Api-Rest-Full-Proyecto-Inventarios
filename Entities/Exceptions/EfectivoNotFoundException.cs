using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EfectivoNotFoundException : NotFoundException
    {
        public EfectivoNotFoundException(Guid EfectivoId)
            : base($"EntidadBancaria with id: {EfectivoId} doesn't exist in the database.")
        {
        }
    }
}
