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
using BooksPlugin.migrations.tables;

namespace BooksPlugin.migrations.migrationplans
{
    public class AddBookTable : MigrationBase
    {
        public AddBookTable(IMigrationContext context) : base(context)
        {

        }

        public override void Migrate()
        {
            Logger.Debug<AddBookTable>("Running migration {MigrationStep}", "AddBookTable");

            if (TableExists("Book") == false)
            {
                Create.Table<Book>().Do();
            }
            else
            {
                Logger.Debug<AddBookTable>("The database table {DbTable} already exists, skipping", "Book");
            }

            Logger.Debug<AddBookTable>("Finished migration {MigrationStep}", "AddBookTable");

        }

    }
}