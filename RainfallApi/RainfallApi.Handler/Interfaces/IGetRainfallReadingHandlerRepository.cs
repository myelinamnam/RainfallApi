using RainfallApi.Core.Models;

namespace RainfallApi.Handler.Interfaces
{
    public interface IGetRainfallReadingHandlerRepository
    {
        Task<GetRainfallReadingResponse> HandleGetRainfallReadingCommandHandler(int invoiceNumber = 0, int customerId = 0);
    }
}
