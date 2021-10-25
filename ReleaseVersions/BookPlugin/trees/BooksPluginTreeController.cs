using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Umbraco.Core;
using Umbraco.Web.Actions;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using Umbraco.Web.WebApi.Filters;

namespace BooksPlugin.trees
{
    public class CustomMenuOption
    {
        public CustomMenuOption(string title, string url)
        {
            this.Title = title;
            this.URL = url;
        }

       public string Title { get; set; }
       public string URL { get; set; }
    }


    [Tree("booksPlugin", "booksPluginTree", TreeTitle = "Bookshop", TreeGroup = "booksPluginGroup", SortOrder = 6)]
    [PluginController("BooksPlugin")]
    public class BooksPluginTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, [ModelBinder(typeof(HttpQueryStringModelBinder))] FormDataCollection queryStrings)
        {
            // check if we're rendering the root node's children
            if (id == Constants.System.Root.ToInvariantString())
            {
                Dictionary<int, CustomMenuOption> customMenuOptions = new Dictionary<int, CustomMenuOption>();

                // CREATE SIDE MENU
                string folderPath = "booksPlugin/booksPluginTree";
                customMenuOptions.Add(1, new CustomMenuOption("Overview", folderPath + "/overview"));
                customMenuOptions.Add(2, new CustomMenuOption("About", folderPath + "/about"));

                var nodes = new TreeNodeCollection();

                // ITERATE MENU ITEMS
                foreach (var item in customMenuOptions)
                {
                    var node = CreateTreeNode(item.Key.ToString(), "-1", queryStrings, item.Value.Title, "icon-favorite", false, item.Value.URL);

                    nodes.Add(node);
                }
                return nodes;
            }

            // this tree doesn't support rendering more than 1 level
            throw new NotSupportedException();
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            // create a Menu Item Collection to return so people can interact with the nodes in your tree
            var menu = new MenuItemCollection();

            if (id == Constants.System.Root.ToInvariantString())
            {
                // root actions, perhaps users can create new items in this tree, or perhaps it's not a content tree, it might be a read only tree, or each node item might represent something entirely different...
                // add your menu item actions or custom ActionMenuItems
                menu.Items.Add(new CreateChildEntity(Services.TextService));
                // add refresh menu item (note no dialog)
                menu.Items.Add(new RefreshNode(Services.TextService, true));

                return menu;
            }
            // add a delete action to each individual item
            menu.Items.Add<ActionDelete>(Services.TextService, true, opensDialog: true);

            return menu;
        }

    }
}