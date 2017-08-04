using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Portable
{
    class TodoDatabase
    {
        SQLiteConnectionWithLock connection;
        TableQuery<Todo> todoTable;

        public TodoDatabase(IConnection db)
        {
            this.connection = db.GetConnection();

            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";

            var result = this.connection.ExecuteScalar<string>(cmdText, "Todo");
            if (result == null)
            {
                this.connection.CreateTable<Todo>();
            }
            this.todoTable = this.connection.Table<Todo>();
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
                retorno = this.connection.Insert(todo);
            else
                retorno = this.connection.Update(todo);
            return todo;
        }

        public void DeleteTodo(int id)
        {
            this.todoTable.Delete(t => t.Id == id);
        }
    }
}
