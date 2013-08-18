using Eloqua.Api.Bulk.Models.Contacts;
using RestSharp;
using System.Collections.Generic;
using Eloqua.Api.Bulk.Models;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactFilterClient
    {
        readonly BaseClient _client;

        public ContactFilterClient(BaseClient client)
        {
            _client = client;
        }

        public List<ContactFilter> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = string.Format("/contact/fields?search={0}&page={1}&pageSize={2}", searchTerm, page, pageSize)
            };

            IRestResponse<SearchResponse<ContactFilter>> response = _client.Get<SearchResponse<ContactFilter>>(request);
            return response.Data.elements;
        }
    }
}