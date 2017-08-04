using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Todo.Portable.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public static Context AppContext;

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();


            TodoRepositorio.Connection = new ConnectionImpl();
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            throw new NotImplementedException();
        }

        public void OnActivityDestroyed(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityPaused(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityResumed(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStarted(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStopped(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}