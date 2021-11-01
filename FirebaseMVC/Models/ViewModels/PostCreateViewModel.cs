using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readz.GoogleBooks.Models;

namespace Readz.Models.ViewModels
{
    public class PostCreateViewModel
    {
        public GoogleBooksItem Book { get; set; }

        public Post Post { get; set;}

        public int CurrentUserId { get; set; }
    }
}
