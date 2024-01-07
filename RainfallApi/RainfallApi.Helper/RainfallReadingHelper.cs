using RainfallApi.Application.Interfaces;
using RainfallApi.Core.Models;

namespace RainfallApi.Helper
{
    public class RainfallReadingHelper : IRainfallReadingHelper
    {
        #region GET
        public async Task<GetRainfallReadingResponse> GetAllReadings(int stationId)
        {
            GetRainfallReadingResponse result = new();
            try
            {
                string url = $"{stationId}/readings";
                {
                    result = await RainfallReadingHttpFunction.Get<GetRainfallReadingResponse>("", "", ApiVersion.V1, url);
                }
            }
            catch (Exception ex)
            {
                //=======================================================================
                // SAVE ERROR LOGS
                //=======================================================================
            }

            //=======================================================================
            // SAVE LOGS
            //=======================================================================
            return result;
        }
        #endregion


        #region POST
        #endregion


        #region PUT
        #endregion


        #region DELETE
        #endregion


        #region PATCH
        #endregion


        #region HEAD
        #endregion


        #region OPTIONS
        #endregion
    }
}