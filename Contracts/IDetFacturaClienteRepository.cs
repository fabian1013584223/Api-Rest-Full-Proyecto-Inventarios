﻿using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDetFacturaClienteRepository
    {
        IEnumerable<DetalleFacturaCliente> GetAllDetSaleBills(bool trackChanges);
        DetalleFacturaCliente GetDetSaleBill(Guid id, bool trackChanges);
    }
}
