namespace RefDef.Web.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
    }
}