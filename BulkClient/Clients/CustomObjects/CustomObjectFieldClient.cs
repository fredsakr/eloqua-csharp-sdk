using Eloqua.Api.Bulk.Models;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectFieldClient
    {
        readonly BaseClient _client;

        public CustomObjectFieldClient(BaseClient client)
        {
            _client = client;
        }

        public SearchResponse<Field> Search(int customObjectId, string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = string.Format("/customObject/{0}/fields??search={1}&page={2}&pageSize={3}", customObjectId, searchTerm, page, pageSize)
            };

            return _client.Execute<SearchResponse<Field>>(request);
        }
    }
}
