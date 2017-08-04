using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace Todo.Portable.iOS
{
    [Register("TodoListViewController")]
    partial class TodoListViewController
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem newTodoButton { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (newTodoButton != null)
            {
                newTodoButton.Dispose();
                newTodoButton = null;
            }
        }
    }
}