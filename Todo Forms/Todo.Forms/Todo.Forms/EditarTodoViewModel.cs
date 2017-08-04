using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Todo.Forms
{
    public class EditarTodoViewModel : BaseViewModel
    {

        public EditarTodoViewModel()
        {
            title = "Editar Todo";
            cancelarText = "Cancelar";
        }

        string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        Todo todo;
        public Todo Todo
        {
            get => todo;
            set {
                if(value?.Id > 0)
                {
                    CancelarText = "Excluir";
                }
                SetProperty(ref todo, value);
            }
        }

        string cancelarText;
        public string CancelarText
        {
            get => cancelarText;
            set => SetProperty(ref cancelarText, value);
        }

        ICommand salvarCommand;
        public ICommand SalvarCommand => salvarCommand ?? (salvarCommand = new Command(async () =>
        {
            TodoRepositorio.Current.SaveTodo(todo);

            var navigationPage = App.Current.MainPage as NavigationPage;
            if (navigationPage == null) return;

            await navigationPage.PopAsync();
        }));

        ICommand cancelarCommand;
        public ICommand CancelarCommand => cancelarCommand ?? (cancelarCommand = new Command(async () =>
        {
            if(todo.Id > 0)
            {
                TodoRepositorio.Current.DeleteTodo(todo.Id);
            }

            var navigationPage = App.Current.MainPage as NavigationPage;
            if (navigationPage == null) return;

            await navigationPage.PopAsync();
        }));
    }
}
