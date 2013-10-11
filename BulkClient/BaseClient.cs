using Eloqua.Api.Bulk.Clients;
using RestSharp;
using RestSharp.Deserializers;

namespace Eloqua.Api.Bulk
{
    public class BaseClient : RestClient
    {
        internal RestClient Client { get; set; }

        protected BaseClient() {}

        public BaseClient(string site, string user, string password, string baseUrl)
        {
            Client = new RestClient
            {
                BaseUrl = baseUrl,
                Authenticator = new HttpBasicAuthenticator(site + "\\" + user, password)
            };

            Client.AddHandler("text/plain", new JsonDeserializer());
        }

        internal T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = Client.Execute<T>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw Validation.ResponseValidator.GetExceptionFromResponse(response);
            }
            return response.Data;
        }

        public SyncClient Syncs
        {
            get { return _syncClient ?? (_syncClient = new SyncClient(this)); }
        }
        private SyncClient _syncClient;

        public JsonDataClient JsonData
        {
            get { return _jsonDataClient ?? (_jsonDataClient = new JsonDataClient(this)); }
        }
        private JsonDataClient _jsonDataClient;
    }
}