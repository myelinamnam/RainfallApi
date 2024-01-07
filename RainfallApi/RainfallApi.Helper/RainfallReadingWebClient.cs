using RainfallApi.Core.Models;
using System.Net;
using System.Text;

namespace RainfallApi.Helper
{
    internal class RainfallReadingWebClient : IDisposable
    {
        private readonly string installation;
        static RainfallReadingWebClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public RainfallReadingWebClient(string installation)
        {
            this.installation = ValidateInstallation(installation);
        }

        private static string ValidateInstallation(string installation)
        {
            if (installation == null)
            {
                throw new ArgumentNullException(nameof(installation), "Installation cannot be null.");
            }

            return installation;
        }

        public async Task<string> OpenGet(string token, ApiVersion apiVersion, string url)
        {
            string retVal = await SendRequest(token, RequestAction.GET, apiVersion, url, null);
            return retVal;
        }


        public async Task<string> GetPost(string token, ApiVersion apiVersion, string url, object jsonObj, string auth = "")
        {
            return await SendRequest(token, RequestAction.POST, apiVersion, url, jsonObj, auth);
        }


        public async Task<string> GetPut(string token, ApiVersion apiVersion, string url, object jsonObj, string auth)
        {
            return await SendRequest(token, RequestAction.PUT, apiVersion, url, jsonObj, auth);
        }


        public void GetDelete(string token, ApiVersion apiVersion, string url)
        {
            _ = SendRequest(token, RequestAction.DELETE, apiVersion, url, null);
        }


        public async Task<string> GetDeleteRead(string token, ApiVersion apiVersion, string url)
        {
            return await SendRequest(token, RequestAction.DELETE, apiVersion, url, null);
        }


        public async Task<string> SendRequest(string token, RequestAction method, ApiVersion apiVersion, string url, object? jsonObj, string auth = "")
        {
            string content = jsonObj switch
            {
                string str => str,
                _ => jsonObj?.ToJson() ?? string.Empty
            };

            string fullUrl = url;
            using HttpClient client = new();
            client.BaseAddress = new Uri(fullUrl);
            client.DefaultRequestHeaders.Add("Accept", apiVersion == ApiVersion.Payment ? "application/vnd.bc.v1+json" : "application/json");
            client.DefaultRequestHeaders.Add("X-Auth-Token", token);

            HttpResponseMessage response;

            switch (method)
            {
                case RequestAction.GET:
                    response = await client.GetAsync(fullUrl);
                    break;
                case RequestAction.POST:
                    response = await client.PostAsync(fullUrl, new StringContent(content, Encoding.UTF8, "application/json"));
                    break;
                case RequestAction.PUT:
                    response = await client.PutAsync(fullUrl, new StringContent(content, Encoding.UTF8, "application/json"));
                    break;
                case RequestAction.DELETE:
                    response = await client.DeleteAsync(fullUrl);
                    break;
                default:
                    throw new Exception($"Method '{method}' not supported");
            }

            string returnedData = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return returnedData;
            }
            else
            {
                ErrorResponse res = returnedData.FromJson<ErrorResponse>(null);
                if (res == null)
                {
                    throw new Exception($"Error invoking Web API URL: {url}");
                }
                else
                {
                    throw new Exception(res.title);
                }
            }
        }



        public void Dispose()
        { }

    }
}
