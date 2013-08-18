using RestSharp;
using System.Collections.Generic;
using Eloqua.Api.Bulk.Models;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactFieldClient
    {
        readonly BaseClient _client;

        public ContactFieldClient(BaseClient client)
        {
            _client = client;
        }

        public SearchResponse<Field> Search(string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = string.Format("/contact/fields?search={0}&page={1}&pageSize={2}", searchTerm, page, pageSize)
            };

            return _client.Execute<SearchResponse<Field>>(request);
        }
    }
}