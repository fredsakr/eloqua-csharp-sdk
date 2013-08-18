namespace Eloqua.Api.Bulk.Models.Errors
{
    public class ObjectValidationError
    {
        public ObjectKey container { get; set; }
        public string property { get; set; }
        public string requirement { get; set; }
        public string value { get; set; }
    }
}
