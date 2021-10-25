using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using BooksPlugin.models;
using Umbraco.Core.Scoping;

namespace BooksPlugin.api
{

    [PluginController("BooksPlugin")]
    public class BookShopController : UmbracoApiController
    {

        private readonly IScopeProvider _scopeProvider;
        public BookShopController(IScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        [HttpPost]
        public ServiceResponse<IEnumerable<BookDTO>> GetBooks()
        {
            ServiceResponse<IEnumerable<BookDTO>> serviceResponse = new ServiceResponse<IEnumerable<BookDTO>>();

            using (var scope = _scopeProvider.CreateScope())
            {
                var results = scope.Database.Query<BookDTO>("SELECT * FROM Book");

                serviceResponse.Results = results;
                serviceResponse.Success = (results.Count() > 0);

                // always complete scope
                scope.Complete();
            }

            return serviceResponse;
        }

        [HttpPost]
        public ServiceResponse<BookDTO> GetBookByID(int bookid)
        {
            ServiceResponse<BookDTO> serviceResponse = new ServiceResponse<BookDTO>();

            using (var scope = _scopeProvider.CreateScope())
            {
                var results = scope.Database.ExecuteScalar<BookDTO>(string.Format("SELECT * FROM Book WHERE BookID={0}", bookid));

                serviceResponse.Results = results;
                serviceResponse.Success = (results != null); 

                // always complete scope
                scope.Complete();
            }

            return serviceResponse;
        }

    }
}