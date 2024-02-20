using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class StockNotFoundException : NotFoundException
    {
        public StockNotFoundException(Guid stockId)
            : base($"The stock with id: {stockId} doesn't exist in the database.")
        {
        }
    }
}
