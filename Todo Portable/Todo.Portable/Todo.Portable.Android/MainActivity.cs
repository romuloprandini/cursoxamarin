using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Todo.Portable.Droid
{
	[Activity (Label = "Todo.Portable.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        ListView listView;
        TodoListAdapter taskList;
        IList<Todo> listaTodo;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            listView = FindViewById<ListView>(Resource.Id.todoListView);

            listView.ItemClick += (sender, e) =>
            {
                var todoEdit = new Intent(this, typeof(TodoEditActivity));
                todoEdit.PutExtra("TodoId", listaTodo[e.Position].Id);
                StartActivity(todoEdit);
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            listaTodo = TodoRepositorio.Current.ListTodo();

            // create our adapter
            taskList = new TodoListAdapter(this, listaTodo);

            //Hook up our adapter to our ListView
            listView.Adapter = taskList;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Create the actions in the ActionBar.
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_new_todo:
                    // The user has tapped the add task button
                    StartActivity(typeof(TodoEditActivity));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
    }
}


