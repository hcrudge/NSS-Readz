using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readz.GoogleBooks.Models
{
    public class GoogleBooksVolumeInfo
    {
        //This class is to return the volume information 
        //which is a nested "items" object in the GoogleBooks response.
        public string Title { get; set; }
        public List<string> Authors { get; set; }

        public string Description { get; set; }

        public string PublishedDate { get; set; }

        public GoogleBooksImage ImageLinks { get; set; }
    }
}
