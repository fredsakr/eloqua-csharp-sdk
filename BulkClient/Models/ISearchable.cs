namespace Eloqua.Api.Bulk.Models
{
    public interface ISearchable
    {
        int page { get; set; }
        int pageSize { get; set; }
        string searchTerm { get; set; }
    }
}
