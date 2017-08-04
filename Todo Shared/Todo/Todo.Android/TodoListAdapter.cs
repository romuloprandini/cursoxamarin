using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Todo.Shared;

namespace Todo.Droid
{
    public class TodoListAdapter : BaseAdapter<Shared.Todo>
    {
        protected Activity context = null;
        protected IList<Shared.Todo> todos = new List<Shared.Todo>();

        public TodoListAdapter(Activity context, IList<Shared.Todo> todos) : base ()
		{
            this.context = context;
            this.todos = todos;
        }

        public override Shared.Todo this[int position] => this.todos[position];

        public override int Count => this.todos.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = todos[position];
            View view;
            
            if (convertView == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.TodoListItem, null);
            }
            else
            {
                view = convertView;
            }

            var nomeTextView = view.FindViewById<TextView>(Resource.Id.nomeTextView);
            nomeTextView.Text = item.Nome;
            var anotacaoTextView = view.FindViewById<TextView>(Resource.Id.AnotacaoTextView);
            anotacaoTextView.Text = item.Anotacao;
            
            var finalizadoImageView = view.FindViewById<ImageView>(Resource.Id.finalizadoImageView);
            finalizadoImageView.Visibility = item.Finalizado ? ViewStates.Visible : ViewStates.Gone;
            
            return view;
        }
    }
}