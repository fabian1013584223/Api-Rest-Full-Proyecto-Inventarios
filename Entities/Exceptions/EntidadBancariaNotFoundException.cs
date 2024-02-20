using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EntidadBancariaNotFoundException : NotFoundException
    {
        public EntidadBancariaNotFoundException(Guid EntidadBancariaId)
            : base($"EntidadBancaria with id: {EntidadBancariaId} doesn't exist in the database.")
        {
        }
    }
}
