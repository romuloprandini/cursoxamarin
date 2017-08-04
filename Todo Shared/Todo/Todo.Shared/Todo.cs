using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Shared
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Anotacao { get; set; }
        public bool Finalizado { get; set; }
    }
}
