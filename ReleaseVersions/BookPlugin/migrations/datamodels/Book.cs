using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksPlugin.migrations.datamodels
{
    /* Setting up a data model without a primary key. This is for migrations only, not for saving or retrieving data via Umbraco website.
     * It has no primary key, BookID, because Umbraco will throw an error saying it "cannot insert explicit value for identity column in table 'Book' when IDENTITY_INSERT is set to OFF."
     * This is a workaround
     */

    public class Book
    {
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}