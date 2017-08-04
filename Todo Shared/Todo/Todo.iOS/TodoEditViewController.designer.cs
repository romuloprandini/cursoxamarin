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
    [Register ("TodoEditViewController")]
    partial class TodoEditViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView anotacaoText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cancelarButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch finalizadoSwich { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nomeText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton salvarButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (anotacaoText != null) {
                anotacaoText.Dispose ();
                anotacaoText = null;
            }

            if (cancelarButton != null) {
                cancelarButton.Dispose ();
                cancelarButton = null;
            }

            if (finalizadoSwich != null) {
                finalizadoSwich.Dispose ();
                finalizadoSwich = null;
            }

            if (nomeText != null) {
                nomeText.Dispose ();
                nomeText = null;
            }

            if (salvarButton != null) {
                salvarButton.Dispose ();
                salvarButton = null;
            }
        }
    }
}