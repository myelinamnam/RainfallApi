using MediatR;
using RainfallApi.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace RainfallApi.Handler.Commands
{
    public class GetRainfallReadingCommandHandler : IRequest<GetRainfallReadingResponse>
    {
        public int stationId { get; set; }
        public int count { get; set; }
        public GetRainfallReadingCommandHandler([Required]int stationId = 0, int count = 10)
        {
            this.stationId = stationId;
            this.count = count;
        }
    }
}
