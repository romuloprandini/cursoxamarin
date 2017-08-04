using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Todo.Portable.iOS
{
    public partial class TodoEditViewController : UIViewController
    {

        private Todo currentTodo;
        public TodoListViewController Delegate { get; set; }

        public TodoEditViewController(IntPtr handle) : base(handle)
        {
            currentTodo = new Todo();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            salvarButton.TouchUpInside += (sender, e) =>
            {
                currentTodo.Nome = nomeText.Text;
                currentTodo.Anotacao = anotacaoText.Text;
                currentTodo.Finalizado = finalizadoSwich.On;
                bool isNewTodo = (currentTodo.Id < 1);
                currentTodo = TodoRepositorio.Current.SaveTodo(currentTodo);

                if (isNewTodo)
                {
                    Delegate.Todos.Add(currentTodo);
                }
                NavigationController.PopViewController(true);
            };

            cancelarButton.TouchUpInside += (sender, e) =>
            {
                if (currentTodo.Id > 0)
                {
                    TodoRepositorio.Current.DeleteTodo(currentTodo.Id);
                    Delegate.Todos.Remove(currentTodo);
                }

                NavigationController.PopViewController(true);
            };
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            nomeText.Text = currentTodo.Nome;
            anotacaoText.Text = currentTodo.Anotacao;
            finalizadoSwich.On = currentTodo.Finalizado;

            if (currentTodo.Id > 0)
            {
                cancelarButton.SetTitle("Excluir", UIControlState.Normal);
            }
        }

        // this will be called before the view is displayed
        public void SetTodo(TodoListViewController d, Todo todo)
        {
            Delegate = d;
            currentTodo = todo;
        }

    }
}