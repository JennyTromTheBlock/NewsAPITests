using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace infrastructure.Models;

public class Article
{
    public int ArticleId { get; set; }

    [Required(ErrorMessage = "Headline is required")]
    [MinLength(5, ErrorMessage = "Headline min. length is 5"), 
     MaxLength(30, ErrorMessage = "Headline max. length is 30")]
    public string Headline { get; set; }

    [Required(ErrorMessage = "Body is required")]
    [MaxLength(1000, ErrorMessage = "Body max. length is 1000")]
    public string Body { get; set; }

    [Required]
    [RegularExpression("Bob|Rob|Dob|Lob", ErrorMessage = "Author must be named Bob, Rob, Dob, or Lob")]
    public string Author { get; set; }

    public string ArticleImgUrl { get; set; }
}