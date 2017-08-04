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

namespace Todo.Droid
{
    [Activity(Label = "Todo Editar")]
    public class TodoEditActivity : Activity
    {

        protected Shared.Todo todo;
        protected EditText anotacaoTextEdit;
        protected EditText nomeTextEdit;
        CheckBox finalizadoCheckbox;
        Button salvarButton;
        Button cancelarButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            todo = new Shared.Todo();

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            // set our layout to be the home screen
            SetContentView(Resource.Layout.EditTodo);
            nomeTextEdit = FindViewById<EditText>(Resource.Id.nomeEditText);
            anotacaoTextEdit = FindViewById<EditText>(Resource.Id.anotacaoEditText);
            finalizadoCheckbox = FindViewById<CheckBox>(Resource.Id.finalizadoCheckBox);
            salvarButton = FindViewById<Button>(Resource.Id.salvarButton);
            cancelarButton = FindViewById<Button>(Resource.Id.cancelarButton);

            int todoId = Intent.GetIntExtra("TodoId", 0);
            if (todoId > 0)
            {
                todo = Shared.TodoRepositorio.Current.GetTodo(todoId);
                cancelarButton.Text = "Excluir";
            }
            
            if (nomeTextEdit != null) { nomeTextEdit.Text = todo.Nome; }
            
            if (anotacaoTextEdit != null) { anotacaoTextEdit.Text = todo.Anotacao; }

            if (finalizadoCheckbox != null) { finalizadoCheckbox.Checked = todo.Finalizado; }

            salvarButton.Click += (sender, e) =>
            {
                Save();
            };

            cancelarButton.Click += CancelDelete;
        }

        protected void Save()
        {
            todo.Nome = nomeTextEdit.Text;
            todo.Anotacao = anotacaoTextEdit.Text;
            todo.Finalizado = finalizadoCheckbox.Checked;
            Shared.TodoRepositorio.Current.SaveTodo(todo);
            Finish();
        }

        protected void CancelDelete(object sender, EventArgs e)
        {
            if (todo.Id != 0)
            {
                Shared.TodoRepositorio.Current.DeleteTodo(todo.Id);
            }
            Finish();
        }

        public override bool OnNavigateUp()
        {
            Finish();
            return base.OnNavigateUp();
        }
        
    }
}