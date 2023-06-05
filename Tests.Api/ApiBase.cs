using RestSharp;
using Tests.Framework.Helpers.Configuration;

namespace Tests.Api
{
    public class ApiBase
    {
        public static string BaseUrl => ConfigurationProvider.TestsConfiguration["ApiUrl"];
        public RestClient restClient;
        public virtual Url? RelativeUri { get; set; }

        public ApiBase() 
        {
            restClient = new RestClient(new RestClientOptions(new Uri(BaseUrl)));
        }
    }
}