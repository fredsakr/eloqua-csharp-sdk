namespace Eloqua.Api.Bulk.Models
{
    public class RestObject : IIdentifiable
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string type;
    }
}
