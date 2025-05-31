namespace RefDef.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedDate { get; set; }

        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
    }
}
