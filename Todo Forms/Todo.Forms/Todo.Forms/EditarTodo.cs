using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Todo.Forms
{
    public class EditarTodo : ContentPage
    {
        public EditarTodo(Todo todo = null)
        {
            todo = todo ?? new Todo();
            BindingContext = new EditarTodoViewModel { Todo = todo };

            CriarLayout();
        }

        public void CriarLayout()
        {

            var nomeEntry = new Entry { Placeholder = "Nome" };
            var anotacaoEditor = new Editor();
            var finalizadoSwitch = new Switch();
            var salvarButtom = new Button { Text = "Salvar" };
            var cancelarButtom = new Button { Text = "Cancelar" };

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Nome" },
                    nomeEntry,
                    new Label { Text = "Anotacao" },
                    anotacaoEditor,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label { Text = "Finalizado" },
                            finalizadoSwitch
                        }
                    },
                    salvarButtom,
                    cancelarButtom
                }
            };

            nomeEntry.SetBinding(Entry.TextProperty, "Todo.Nome");
            anotacaoEditor.SetBinding(Editor.TextProperty, "Todo.Anotacao");
            finalizadoSwitch.SetBinding(Switch.IsToggledProperty, "Todo.Finalizado");
            salvarButtom.SetBinding(Button.CommandProperty, "SalvarCommand");
            cancelarButtom.SetBinding(Button.CommandProperty, "CancelarCommand");
            cancelarButtom.SetBinding(Button.TextProperty, "CancelarText");
        }
    }
}