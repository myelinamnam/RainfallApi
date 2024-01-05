using MediatR;
using RainfallApi.Application.Interfaces;
using RainfallApi.Core.Models;
using RainfallApi.Handler.Commands;
using System.ComponentModel.DataAnnotations;

namespace RainfallApi.Infrastructure.Repositories
{
    public class RainfallRepository : IRainfallRepository
    {
        private readonly IMediator _mediator;
        public RainfallRepository(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Get([Range(1, 100, ErrorMessage = "Value for {stationId} must be between {1} and {100}.")][Required(ErrorMessage = "stationId is required")] int stationId, int count = 10)
        {
            return await _mediator.Send(new GetRainfallReadingCommandHandler(stationId, count));
        }
    }
}