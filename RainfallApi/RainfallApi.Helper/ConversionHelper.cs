using Newtonsoft.Json;

namespace RainfallApi.Helper
{
    public static class ConversionHelper
    {
        public static string ToJson(this object obj)
        {
            string result = JsonConvert.SerializeObject(obj);
            return result;
        }

        public static T? FromJson<T>(this string jsonStr, T defaultValue)
        {

            T? result = JsonConvert.DeserializeObject<T>(jsonStr);
            return result;

        }
    }
}
