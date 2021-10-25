using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksPlugin.models
{
    public class ServiceResponse<T>
    {
        public T Results { get; set; }
        public bool Success { get; set; }
    }
}