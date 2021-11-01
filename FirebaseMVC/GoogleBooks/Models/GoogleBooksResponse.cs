using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readz.GoogleBooks.Models
{
    public class GoogleBooksResponse
    {
        public string Kind { get; set; }

        public int TotalItems { get; set; }

        public List<GoogleBooksItem> Items { get; set; }

        public GoogleBooksItem Item { get; set; }
    }
}
