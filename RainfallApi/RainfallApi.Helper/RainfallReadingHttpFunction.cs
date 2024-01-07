using Microsoft.Extensions.Options;
using RainfallApi.Core.Models;

namespace RainfallApi.Helper
{
    internal class RainfallReadingHttpFunction
    {
        private readonly AppSettings _settings;
        public RainfallReadingHttpFunction(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }


        internal static async Task<T> Get<T>(string token, string installation, ApiVersion apiVersion, string url)
        {
            url = $"{GetBaseUrl(apiVersion, installation).TrimEnd('/')}/{url.TrimStart('/')}";

            if (installation == null)
                throw new ArgumentNullException(nameof(installation));

            using RainfallReadingWebClient client = new(installation);
            string jsonData = await client.OpenGet(token, apiVersion, url);
            T retval = jsonData.FromJson<T>(default(T));
            return retval;
        }

        internal static async Task<T> PostReader<T>(string token, string installation, ApiVersion apiVersion, string url, object jsonObj, string auth = "")
        {
            url = $"{GetBaseUrl(apiVersion, installation).TrimEnd('/')}/{url.TrimStart('/')}";
            using RainfallReadingWebClient client = new(installation);
            string jsonData = await client.GetPost(token, apiVersion, url, jsonObj, auth);
            T retval = jsonData.FromJson<T>(default(T));
            return retval;
        }


        internal static async Task<T> PutReader<T>(string token, string installation, ApiVersion apiVersion, string url, object jsonObj, string auth = "")
        {
            url = $"{GetBaseUrl(apiVersion, installation).TrimEnd('/')}/{url.TrimStart('/')}";
            using RainfallReadingWebClient client = new(installation);
            string jsonData = await client.GetPut(token, apiVersion, url, jsonObj, auth);
            T retval = jsonData.FromJson<T>(default(T));
            return retval;
        }


        internal static void DeleteCommand(string token, string installation, ApiVersion apiVersion, string url)
        {
            url = $"{GetBaseUrl(apiVersion, installation).TrimEnd('/')}/{url.TrimStart('/')}";
            if (string.IsNullOrEmpty(installation))
            {
                throw new ArgumentNullException(nameof(installation));
            }

            using RainfallReadingWebClient client = new(installation);
            client?.GetDelete(token, apiVersion, url);
        }



        internal static async Task<T> DeleteRead<T>(string token, string installation, ApiVersion apiVersion, string url)
        {
            url = $"{GetBaseUrl(apiVersion, installation).TrimEnd('/')}/{url.TrimStart('/')}";
            using RainfallReadingWebClient client = new(installation);
            string jsonData = await client.GetDeleteRead(token, apiVersion, url);
            T retval = jsonData.FromJson<T>(default(T));
            return retval;
        }


        private static string GetBaseUrl(ApiVersion version, string installation)
        {
            switch (version)
            {
                //=======================================================================
                // PROVISSIONED FOR API URL ENDPOINT THAT HAS VERSIONS
                //=======================================================================
                case ApiVersion.V2:
                    return "https://api.bigcommerce.com/stores/" + installation + "/v2/";
                default:
                    return "http://environment.data.gov.uk/flood-monitoring/id/stations/";
            }
        }
    }
}
