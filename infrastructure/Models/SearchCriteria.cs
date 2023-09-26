using System.ComponentModel.DataAnnotations;

namespace infrastructure.Models;

public class SearchCriteria
{
    [MinLength(3, ErrorMessage = "Searchterm must be at least 3 characters")]
    public string SearchTerm { get; set; }
    public int PageSize { get; set; }
}