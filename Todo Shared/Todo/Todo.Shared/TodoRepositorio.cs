using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using SQLite.Net.Interop;

#if __ANDROID__
using SQLite.Net.Platform.XamarinAndroid;
#endif

#if __IOS__
using SQLite.Net.Platform.XamarinIOS;
#endif

namespace Todo.Shared
{
    public class TodoRepositorio
    {
        private TodoDatabase db;

        private static TodoRepositorio instance;

        public static TodoRepositorio Current {
            get {
                if(instance == null)
                {

                    var sqliteFilename = "todo.db3";
                    ISQLitePlatform sqlitePlatform;
#if __ANDROID__
                    string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                    sqlitePlatform = new SQLitePlatformAndroidN();
#else
                    // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				    // (they don't want non-user-generated data in Documents)
				    string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				    string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
                    sqlitePlatform = new SQLitePlatformIOS();
#endif
                    var path = Path.Combine(libraryPath, sqliteFilename);
                    var param = new SQLiteConnectionString(path, false);
                    var connection = new SQLiteConnectionWithLock(sqlitePlatform, param);

                    instance = new TodoRepositorio(connection);
                }
                return instance;
            }
        }

        private TodoRepositorio(SQLiteConnectionWithLock connection)
        {
            this.db = new TodoDatabase(connection);
        }

        public IList<Todo> ListTodo()
        {
            return this.db.ListTodo();
        }

        public Todo GetTodo(int id)
        {
            return this.db.GetTodo(id);
        }

        public Todo SaveTodo(Todo todo)
        {
            return this.db.SaveTodo(todo);
        }

        public void DeleteTodo(int id)
        {
            this.db.DeleteTodo(id);
        }
    }
}
