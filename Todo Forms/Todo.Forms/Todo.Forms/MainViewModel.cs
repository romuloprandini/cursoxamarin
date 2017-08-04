using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Todo.Forms
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            title = "Todos";
        }

        public void ListTodos()
        {
            Todos = TodoRepositorio.Current.ListTodo();
        }

        string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        IList<Todo> todos;
        public IList <Todo> Todos
        {
            get => todos;
            set => SetProperty(ref todos, value);
        }

        ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new Command(async () =>
        {
            var navigationPage = App.Current.MainPage as NavigationPage;
            if (navigationPage == null) return;

            await navigationPage.PushAsync(new EditarTodo());
        }));

        ICommand editCommand;
        public ICommand EditCommand => editCommand ?? (editCommand = new Command(async todo =>
        {
            var navigationPage = App.Current.MainPage as NavigationPage;
            if (navigationPage == null) return;

            await navigationPage.PushAsync(new EditarTodo((Todo)todo));
        }));
    }
}
