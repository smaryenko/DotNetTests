using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace Tests.Framework.Helpers.Extensions
{
    public static class JsonExtensions
    {
        public static T TryDeserializeJson<T>(this RestResponse httpResponse)
        {
            T result = default(T);
            try
            {
                result = JsonConvert.DeserializeObject<T>(httpResponse.Content);

            }
            catch (Exception e)
            {
                Assert.Fail("Unable to deserialize response content: " + e.Message);
            }

            return result;
        }
    }
}
