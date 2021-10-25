using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.Sections;


namespace BooksPlugin.sections
{ 
    public class BooksPluginSection : ISection
    {
        public string Alias => "booksPlugin";

        public string Name => "Bookshop";
    }
}