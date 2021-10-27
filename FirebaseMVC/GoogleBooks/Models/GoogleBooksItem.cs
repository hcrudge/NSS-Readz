using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readz.GoogleBooks.Models
{
    public class GoogleBooksItem
    {
        //This class is to return the items info
        //which is an object in the GoogleBooks response.
        // (volumeInfo is a nest object of this object)
        public GoogleBooksVolumeInfo VolumeInfo { get; set; }


    }
}
