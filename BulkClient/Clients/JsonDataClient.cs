using RestSharp;

namespace Eloqua.Api.Bulk.Clients
{
    public class JsonDataClient
    {
        readonly BaseClient _client;

        public JsonDataClient(BaseClient client)
        {
            _client = client;
        }

        public IRestResponse ExportData(string exportUri)
        {
            var request = new RestRequest
            {
                Resource = exportUri + "/data",
                RequestFormat = DataFormat.Json
            };

            return _client.Execute(request);
        }
    }
}
