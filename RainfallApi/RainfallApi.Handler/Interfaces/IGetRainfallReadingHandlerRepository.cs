using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallApi.Handler.Interfaces
{
    public interface IGetRainfallReadingHandlerRepository
    {
        Task<string> HandleGetRainfallReadingCommandHandler(int invoiceNumber = 0, int customerId = 0);
    }
}
