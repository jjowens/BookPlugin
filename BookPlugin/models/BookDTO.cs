using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksPlugin.models
{

    public class BookDTO
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

    }
}