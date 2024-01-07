using RainfallApi.Core.Models;

namespace RainfallApi.Application.Interfaces
{
    public interface IRainfallReadingHelper
    {
        Task<GetRainfallReadingResponse> GetAllReadings(int stationId);
    }
}
