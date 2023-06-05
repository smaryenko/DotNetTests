using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Tests.Api.Helpers
{
    public static class RestSharpExtensions
    {
        public static RestResponse GetObject(this RestClient client, string url, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = new RestRequest(url);
            
            var response = client.ExecuteGet(request);
            Assert.AreEqual(httpStatusCode, response.StatusCode);

            return response;
        }

        public static RestResponse CreateObject(this RestClient client, string url, object body, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = new RestRequest(url).AddJsonBody(body);

            var response = client.ExecutePost(request);
            Assert.AreEqual(httpStatusCode, response.StatusCode);

            return response;
        }

        public static RestResponse UpdateObject(this RestClient client, string url, object body, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = new RestRequest(url).AddJsonBody(body);

            var response = client.ExecutePut(request);
            Assert.AreEqual(httpStatusCode, response.StatusCode);

            return response;
        }

        public static RestResponse DeleteObject(this RestClient client, string url, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = new RestRequest(url, Method.Delete);

            var response = client.Execute(request);
            Assert.AreEqual(httpStatusCode, response.StatusCode);

            return response;
        }
    }
}
