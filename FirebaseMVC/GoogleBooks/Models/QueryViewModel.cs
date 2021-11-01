using System.Collections.Generic;


namespace Readz.GoogleBooks.Models
{
    public class QueryViewModel
    {
        public string QueryString { get; set; }

        public List<GoogleBooksItem> Books { get; set; }

        public GoogleBooksItem Book { get; set; }

    }
}
