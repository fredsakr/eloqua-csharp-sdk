using RestSharp;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.CustomObjects;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectClient
    {
        readonly BaseClient _client;

        public CustomObjectClient(BaseClient client)
        {
            _client = client;
        }

        public SearchResponse<CustomObjectSearchResponse> SearchCustomDataObjects(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource =
                    string.Format("/customObjects?search={0}&page={1}&pageSize={2}", searchTerm,
                                  page, pageSize)
            };
            var response = _client.Execute<SearchResponse<CustomObjectSearchResponse>>(request);
            return response;
        }
    }
}
