using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ClienteNotFoundException : NotFoundException
    {
        public ClienteNotFoundException(Guid ClienteId)
            : base($"Employee with id: {ClienteId} doesn't exist in the database.")
        {
        }
    }
}
