using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Todo.Portable.iOS
{
    public class TodoTableSource : UITableViewSource
    {
        TodoListViewController controller;

        public TodoTableSource(TodoListViewController controller)
        {
            this.controller = controller;
        }

        // Returns the number of rows in each section of the table
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return controller.Todos.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(TodoListViewController.TodoCellId);

            int row = indexPath.Row;
            cell.TextLabel.Text = controller.Todos[row].Nome;
            cell.DetailTextLabel.Text = controller.Todos[row].Anotacao;
            if (controller.Todos[indexPath.Row].Finalizado)
                cell.Accessory = UITableViewCellAccessory.Checkmark;
            else
                cell.Accessory = UITableViewCellAccessory.None;
            return cell;
        }

        public Todo GetItem(int id)
        {
            return controller.Todos[id];
        }
    }
}