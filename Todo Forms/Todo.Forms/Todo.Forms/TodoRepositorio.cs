using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo.Forms
{
    public class TodoRepositorio
    {
        private TodoDatabase db;

        private TodoRepositorio()
        {
            db = new TodoDatabase();
        }

        private static TodoRepositorio instance;

        public static TodoRepositorio Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new TodoRepositorio();
                }
                return instance;
            }
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
