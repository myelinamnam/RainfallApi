using RainfallApi.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace RainfallApi.Application.Interfaces
{
    public interface IRainfallRepository
    {
        Task<string> Get([Range(1, 100, ErrorMessage = "Value for {stationId} must be between {1} and {100}.")][Required(ErrorMessage = "stationId is required")] int stationId, int count = 10);
    }
}
