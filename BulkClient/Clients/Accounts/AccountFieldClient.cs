using RestSharp;
using Eloqua.Api.Bulk.Models;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountFieldClient
    {
        readonly BaseClient _client;

        public AccountFieldClient(BaseClient client)
        {
            _client = client;
        }

        public SearchResponse<Field> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = string.Format("/account/fields?search={0}&page={1}&pageSize={2}", searchTerm, page, pageSize)
            };

            return _client.Execute<SearchResponse<Field>>(request);
        }
    }
}
