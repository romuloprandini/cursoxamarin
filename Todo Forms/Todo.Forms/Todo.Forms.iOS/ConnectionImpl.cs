using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SQLite.Net;
using UIKit;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;
using Todo.Forms.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ConnectionImpl))]
namespace Todo.Forms.iOS
{
    public class ConnectionImpl : IConnection
    {
        public SQLiteConnectionWithLock GetConnection()
        {

            var sqliteFilename = "todo.db3";
            // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
            // (they don't want non-user-generated data in Documents)
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "../Library/"); // Library folder
            var sqlitePlatform = new SQLitePlatformIOS();

            var path = Path.Combine(libraryPath, sqliteFilename);
            var param = new SQLiteConnectionString(path, false);
            return new SQLiteConnectionWithLock(sqlitePlatform, param);
        }
    }
}