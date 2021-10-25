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
using BooksPlugin.migrations.migrationplans;

namespace BooksPlugin.migrations.composers
{

    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class BooksComposer : ComponentComposer<BookComponent>
    {

    }

    public class BookComponent : IComponent
    {
        private IScopeProvider _scopeProvider;
        private IMigrationBuilder _migrationBuilder;
        private IKeyValueService _keyValueService;
        private ILogger _logger;

        public BookComponent(IScopeProvider scopeProvider, IMigrationBuilder migrationBuilder, IKeyValueService keyValueService, ILogger logger)
        {
            _scopeProvider = scopeProvider;
            _migrationBuilder = migrationBuilder;
            _keyValueService = keyValueService;
            _logger = logger;
        }

        public void Initialize()
        {
            // CREATE A MIGRATION PLAN TO ADD A TABLE AND THEN POPULATE TABLE
            var migrationPlan = new MigrationPlan("BooksPluginInit");

            migrationPlan.From(string.Empty)
                .To<AddBookTable>("add-book-table")
                .To<InsertBooks>("insert-books");

            var upgrader = new Upgrader(migrationPlan);
            upgrader.Execute(_scopeProvider, _migrationBuilder, _keyValueService, _logger);

        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }


    }
}