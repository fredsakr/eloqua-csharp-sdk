using RestSharp;
using System.Collections.Generic;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Accounts;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountFilterClient
    {
        readonly BaseClient _client;

        public AccountFilterClient(BaseClient client)
        {
            _client = client;
        }

        public List<AccountFilter> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = string.Format("/account/fields?search={0}&page={1}&pageSize={2}", searchTerm, page, pageSize)
            };

            IRestResponse<SearchResponse<AccountFilter>> response = _client.Get<SearchResponse<AccountFilter>>(request);
            return response.Data.elements;
        }
    }
}
