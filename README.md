# BookPlugin
A demo plugin for your Umbraco 8 project

This is a demo plugin created to demostrate migration plans in creating a custom table and then adding a few books.

## Caveats

1. Use this plugin in an Umbraco 8 website.
2. Test this plugin on an isolated Umbraco website, preferably in a local Dev/Test environment
3. You should NOT have an existing table called "Book" in your Umbraco database. If you rename the table name in the plugin to your preferred tablename.

## How To Install

Drop the folder from the release folder into your Umbraco App_Plugins folder. Then (re)boot up your Umbraco website. No need to update configs.

It will create a new table called "Book" and add 6 books.

To see your list of books onscreen, log into your Umbraco website. You need to do this on Umbraco versions 8+ Click on "Users" and then "Groups" (at right hand side). Click on "Administrators". Click on the button "Add", a sidemenu will slide out onscreen. Tick the plugin "Bookshop". Press "Submit" at bottom, the sidemenu will disappear and then you click on "Save" to finalise your update.

Repeat the above steps for any other type of users if you prefer.

## How to work with Plugin and release

You can use Visual Studio Code or Community Edition 2019. If you want to create your own release of this plugin, then make your changes and copy the folder over to your App_Plugins. However, you must delete the following files/folders from your version of the release, they are not needed.

A copy of the release is already set in the ReleaseVersions directory.

bin
obj
packages
Properties
BooksPlugin.csproj
BooksPlugin.csproj.user
BuildEvents.txt
CopyCommands.txt
packages.config
Web.config
Web.debug.config
Web.release.config

## Key files

Those files are worth looking if you would like to know how to set up migration plans.

**AddBookTable.cs**

Path: \BookPlugin\migrations\migrationplans\AddBookTable.cs

This file is a migration script which will create a "Book" table in your Umbraco database.

**InsertBooks.cs**

Path: \BookPlugin\migrations\migrationplans\InsertBooks.cs

This file is a migration script which will add a few records to the Book table. 

**BookShopController.cs**

Path: \BookPlugin\api\BookShopController.cs

The BookShopController.cs file has an API which will return a list of books.

**Overview.html**

Path: \BookPlugin\backoffice\booksPluginTree\overview.html

This is a webpage will list all books from the custom tables

**BooksPluginTreeController.cs**

Path: \BookPlugin\trees\BooksPluginTreeController.cs

This controller will create a few menu items; overview and about