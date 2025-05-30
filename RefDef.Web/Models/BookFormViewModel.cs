using System.Collections.Generic;

namespace RefDef.Web.Models
{
    public class BookFormViewModel
    {
        public Book Book { get; set; } = new();
        public List<Author> Authors { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public List<Publisher> Publishers { get; set; } = new();
    }
}
