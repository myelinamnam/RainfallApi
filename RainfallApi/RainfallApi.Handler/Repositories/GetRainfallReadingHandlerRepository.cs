using Newtonsoft.Json;
using RainfallApi.Application.Interfaces;
using RainfallApi.Core.Models;
using RainfallApi.Handler.Interfaces;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RainfallApi.Handler.Repositories
{
    public class GetRainfallReadingHandlerRepository : IGetRainfallReadingHandlerRepository
    {

        private readonly IRainfallReadingHelper _rainfallReadingHelper;
        public GetRainfallReadingHandlerRepository (IRainfallReadingHelper rainfallReadingHelper)
        {
            _rainfallReadingHelper = rainfallReadingHelper;
        }


        public async Task<GetRainfallReadingResponse> HandleGetRainfallReadingCommandHandler(int stationId = 0, int count = 10)
        {
            GetRainfallReadingResponse result = new();
            try
            {
                result = await _rainfallReadingHelper.GetAllReadings(stationId);

                if (!result.Equals(null) || result.items.Count <= 0)
                    return result;

                else
                {
                    ErrorDetail errorDetail = new()
                    {
                        Message = "Error in calling API",
                        PropertyName = "GetAllReadings"
                    };
                    ErrorResponse errorResponse = new()
                    {
                        status = (int)HttpCode.InterServerError,
                        title = HttpCode.InterServerError.ToString(),
                        type = JsonConvert.SerializeObject(errorDetail)
                    };
                    return result;
                }
            }
            catch (Exception ex) 
            {
                ErrorDetail errorDetail = new()
                {
                    Message = ex.Message,
                    PropertyName = "GetAllReadings"
                };
                ErrorResponse errorResponse = new()
                {
                    status = (int)HttpCode.InterServerError,
                    title = HttpCode.InterServerError.ToString(),
                    type = JsonConvert.SerializeObject(errorDetail)
                };
                return result;
            }
        }
    }
}
