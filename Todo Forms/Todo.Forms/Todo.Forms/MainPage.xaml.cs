using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo.Forms
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainViewModel();

            Task.Delay(2000);
            
            Animation anime = new Animation((b) => { teste.HeightRequest = b; }, 0, 1, Easing.Linear);
            anime.Commit(this, "teste");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ListTodos();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (viewModel?.EditCommand == null || !viewModel.EditCommand.CanExecute(e.SelectedItem)) return;
            viewModel.EditCommand.Execute(e.SelectedItem);
        }
    }
}
