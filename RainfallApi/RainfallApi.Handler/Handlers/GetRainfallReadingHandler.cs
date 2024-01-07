using MediatR;
using RainfallApi.Core.Models;
using RainfallApi.Handler.Commands;
using RainfallApi.Handler.Interfaces;

namespace RainfallApi.Handler.Handlers
{
    public class GetRainfallReadingHandler : IRequestHandler<GetRainfallReadingCommandHandler, GetRainfallReadingResponse>
    {
        private readonly IGetRainfallReadingHandlerRepository _getRainfallReadingHandlerRepository;

        public GetRainfallReadingHandler(IGetRainfallReadingHandlerRepository getRainfallReadingHandlerRepository)
        {
            _getRainfallReadingHandlerRepository = getRainfallReadingHandlerRepository;
        }

        public async Task<GetRainfallReadingResponse> Handle(GetRainfallReadingCommandHandler command, CancellationToken cancellationToken)
        {
            return await _getRainfallReadingHandlerRepository.HandleGetRainfallReadingCommandHandler(command.stationId, command.count);
        }
    }
}
