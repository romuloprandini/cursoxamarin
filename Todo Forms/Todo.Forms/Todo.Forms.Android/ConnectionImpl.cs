﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Todo.Forms;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;
using Todo.Forms.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ConnectionImpl))]
namespace Todo.Forms.Droid
{
    public class ConnectionImpl : IConnection
    {
        public SQLiteConnectionWithLock GetConnection()
        {
            var sqliteFilename = "todo.db3";
            string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var sqlitePlatform = new SQLitePlatformAndroidN();
            var path = Path.Combine(libraryPath, sqliteFilename);
            var param = new SQLiteConnectionString(path, false);
            return new SQLiteConnectionWithLock(sqlitePlatform, param);
        }
    }
}