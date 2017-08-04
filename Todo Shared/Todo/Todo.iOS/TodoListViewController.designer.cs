// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Todo.iOS
{
    [Register ("TodoListViewController")]
    partial class TodoListViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem newTodoButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (newTodoButton != null) {
                newTodoButton.Dispose ();
                newTodoButton = null;
            }
        }
    }
}