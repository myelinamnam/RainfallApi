using RainfallApi.Handler.Interfaces;

namespace RainfallApi.Handler.Repositories
{
    public class GetRainfallReadingHandlerRepository : IGetRainfallReadingHandlerRepository
    {
        public async Task<string> HandleGetRainfallReadingCommandHandler(int invoiceNumber = 0, int customerId = 0)
        {
            return "success";
        }
    }
}
