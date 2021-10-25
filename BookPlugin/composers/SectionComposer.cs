using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Composing;
using Umbraco.Web;
using BooksPlugin.sections;

namespace BooksPlugin.composers
{
    public class SectionComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Sections().Append<BooksPluginSection>();
        }
    }
}