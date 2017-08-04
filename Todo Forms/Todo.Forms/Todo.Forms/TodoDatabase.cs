using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo.Forms
{
    public class TodoDatabase
    {
        SQLiteConnectionWithLock db;
        TableQuery<Todo> todoTable;

        public TodoDatabase()
        {
            var conn = DependencyService.Get<IConnection>();
            this.db = conn.GetConnection();

            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";

            var result = this.db.ExecuteScalar<string>(cmdText, "Todo");
            if (result == null)
            {
                this.db.CreateTable<Todo>();
            }
            this.todoTable = this.db.Table<Todo>();
        }

        public IList<Todo> ListTodo()
        {
            return this.todoTable.ToList();
        }

        public Todo GetTodo(int id)
        {
            return this.todoTable.Where(t => t.Id == id).FirstOrDefault();
        }

        public Todo SaveTodo(Todo todo)
        {
            int retorno;
            if (todo.Id < 1)
                retorno = this.db.Insert(todo);
            else
                retorno = this.db.Update(todo);
            return todo;
        }

        public void DeleteTodo(int id)
        {
            this.todoTable.Delete(t => t.Id == id);
        }
    }
}
