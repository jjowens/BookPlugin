using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Migrations;
using Umbraco.Core.Migrations.Upgrade;
using Umbraco.Core.Persistence.DatabaseAnnotations;
using Umbraco.Core.Scoping;
using Umbraco.Core.Services;
using BooksPlugin.migrations.datamodels;

namespace BooksPlugin.migrations.migrationplans
{
    public class InsertBooks : MigrationBase
    {
        public InsertBooks(IMigrationContext context) : base(context)
        {

        }

        public override void Migrate()
        {
            Logger.Debug<InsertBooks>("Running migration {MigrationStep}", "InsertBooks");

            List<Book> listOfBooks = new List<Book>();

            // CREATE LIST OF BOOKS
            listOfBooks.Add(CreateBook("Salems Lot", "Stephen", "King"));
            listOfBooks.Add(CreateBook("Thursday Murder Club, The", "Richard", "Osman"));
            listOfBooks.Add(CreateBook("Where the Crawdads Sing", "Delia", "Owens"));
            listOfBooks.Add(CreateBook("Normal People", "Sally", "Rooney"));
            listOfBooks.Add(CreateBook("Crossroads", "Jonathan", "Franzen"));
            listOfBooks.Add(CreateBook("Party Crash, The", "Sophie", "Kinsella"));

            // ITERATE EACH BOOK
            foreach(Book book in listOfBooks)
            {
                Insert.IntoTable("Book").Row(book).Do();
            }

            Logger.Debug<InsertBooks>("Finished migration {MigrationStep}", "InsertBooks");

        }

        private Book CreateBook(string title, string firstName, string lastName)
        {
            return new Book()
            {
                Title = title,
                AuthorFirstName = firstName,
                AuthorLastName = lastName
            };
        }

    }
}