using System.Net.Http.Headers;

namespace Pokemon_Evrimpleri.RequestModule
{
    public static class RequestModule
    {
        public static HttpClient FetchClient { get; set; } = new HttpClient();
        public static void initialize()
        {
            FetchClient = new HttpClient();
            FetchClient.DefaultRequestHeaders.Accept.Clear();
            FetchClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
    }
}
