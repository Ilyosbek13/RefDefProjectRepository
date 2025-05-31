using RefDef.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string ISBN { get; set; } = null!;

    [Required]
    public int Pages { get; set; }

    [Required]
    public DateTime PublishedDate { get; set; }
    
    [Required]
    public int AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public Author? Author { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; } 

    [Required]
    public int PublisherId { get; set; }

    [ForeignKey("PublisherId")]
    public Publisher? Publisher { get; set; }
}
