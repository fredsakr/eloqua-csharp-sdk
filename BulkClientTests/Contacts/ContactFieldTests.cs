using System.Collections.Generic;
using Eloqua.Api.Bulk.Models;
using NUnit.Framework;

namespace Eloqua.Api.Bulk.Tests.Contacts
{
    [TestFixture]
    public class ContactFieldTests
    {
        private BulkClient _client;

        [TestFixtureSetUp]
        public void Init()
        {
            var accountInfo = BulkClient.GetAccountInfo(Constants.Site, Constants.User, Constants.Passwd);

            _client = new BulkClient(Constants.Site, Constants.User, Constants.Passwd, Helpers.CurrentApiVersion(accountInfo));
        }

        [Test]
        public void GetContactFieldsTest()
        {
            SearchResponse<Field> fields = _client.ContactFields.Search("*", 1, 1);
            Assert.AreEqual(1, fields.total);
        }
    }
}
