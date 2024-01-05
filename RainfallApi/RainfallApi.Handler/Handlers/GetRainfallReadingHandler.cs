using MediatR;
using RainfallApi.Handler.Commands;
using RainfallApi.Handler.Interfaces;

namespace RainfallApi.Handler.Handlers
{
    public class GetRainfallReadingHandler : IRequestHandler<GetRainfallReadingCommandHandler, string>
    {
        private readonly IGetRainfallReadingHandlerRepository _getRainfallReadingHandlerRepository;

        public GetRainfallReadingHandler(IGetRainfallReadingHandlerRepository getRainfallReadingHandlerRepository)
        {
            _getRainfallReadingHandlerRepository = getRainfallReadingHandlerRepository;
        }

        public async Task<string> Handle(GetRainfallReadingCommandHandler command, CancellationToken cancellationToken)
        {
            return await _getRainfallReadingHandlerRepository.HandleGetRainfallReadingCommandHandler(command.stationId, command.count);
        }
    }
}
