using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TrainingLog2.Fragments
{
    public class NoLogWorkoutFragment : Android.Support.V4.App.Fragment
    {
        private DateTime date;

        public NoLogWorkoutFragment(DateTime date)
        {
            this.date = date;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View mainView = inflater.Inflate(Resource.Layout.content_main, container, false);

            FloatingActionButton fab = mainView.FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            return mainView;
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override string ToString()
        {
            return date.ToString("ddd, dd MMM");
        }
    }
}