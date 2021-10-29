﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readz.GoogleBooks.Models
{
    public class QueryViewModel
    {
        public string QueryString { get; set; }

        public List<GoogleBooksItem> Books { get; set; }

    }
}
