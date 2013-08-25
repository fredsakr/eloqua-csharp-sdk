using System;
using System.Text;

namespace Eloqua.Api.Bulk.Authentication
{
    public class BasicAuthentication
    {
        internal static string BuildAuthHeader(string username, string password)
        {
            string credentials = String.Format("{0}:{1}", username, password);
            byte[] bytes = Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);
            return String.Concat("basic ", base64);
        }
    }
}
