using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Todo.iOS
{
    public partial class TodoListViewController : UITableViewController
    {
        public IList<Shared.Todo> Todos { get; set; }

        public static NSString TodoCellId = new NSString("TodoCell");

        public TodoListViewController(IntPtr handle) : base(handle)
        {
            Todos = Shared.TodoRepositorio.Current.ListTodo();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            TableView.Source = new TodoTableSource(this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "EditTodoSegue" || segue.Identifier == "NewTodoSegue")
            { // set in Storyboard
                var navctlr = segue.DestinationViewController as TodoEditViewController;
                if (navctlr != null)
                {
                    var source = TableView.Source as TodoTableSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    if (segue.Identifier == "EditTodoSegue")
                    {
                        var item = source.GetItem(rowPath.Row);
                        navctlr.SetTodo(this, item);
                    }
                    else
                    {
                        navctlr.SetTodo(this, new Shared.Todo());
                    }
                }
            }
        }
    }
}