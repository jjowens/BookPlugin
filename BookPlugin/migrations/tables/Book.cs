using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPoco;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace BooksPlugin.migrations.tables
{
   // This is a schema class to create a new table. Accordinng to Umbraco documentation, this class should not be used for data retrieval

    [System.Web.DynamicData.TableName("Book")]
    [PrimaryKey("BookID", AutoIncrement = true)]
    [ExplicitColumns]
    public class Book
    {
        [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
        [Column("BookID")]
        public int BookID { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("AuthorFirstName")]
        public string AuthorFirstName { get; set; }

        [Column("AuthorLastName")]
        public string AuthorLastName { get; set; }
    }
}