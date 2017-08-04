using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Portable
{
    public class TodoRepositorio
    {
        private TodoDatabase db;

        public static IConnection Connection { get; set; }

        private static TodoRepositorio instance;

        public static TodoRepositorio Current
        {
            get
            {
                if (Connection == null) throw new Exception("Informe a conexão");

                if (instance == null)
                {
                    instance = new TodoRepositorio();
                }
                return instance;
            }
        }

        private TodoRepositorio()
        {
            db = new TodoDatabase(Connection);
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
