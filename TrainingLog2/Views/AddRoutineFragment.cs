using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using TrainingLog2.SQLiteServices;

namespace TrainingLog2.Views
{
    public class AddRoutineFragment : Android.Support.V4.App.Fragment
    {

        private TextInputEditText tv;
        private SQLiteHandler handler;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            handler = new SQLiteHandler();
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View mainView = inflater.Inflate(Resource.Layout.add_routine_main, container, false);
            tv = mainView.FindViewById<TextInputEditText>(Resource.Id.tvRoutine);
            FloatingActionButton fab = mainView.FindViewById<FloatingActionButton>(Resource.Id.fabAddRoutine);

            fab.Click += AddRoutine;

            return mainView;
        }

        private void AddRoutine(object sender, EventArgs eventArgs)
        {
            if (tv.Text.Length > 0)
            {
                handler.InsertRoutine(tv.Text);
                Android.Support.V4.App.Fragment fragment_workout = FragmentManager.FindFragmentByTag("WORKOUT_FRAGMENT");
                if (fragment_workout == null || !fragment_workout.IsVisible)
                {
                    FragmentManager.BeginTransaction().Replace(Resource.Id.flContent, new EditWorkoutFragment(), "WORKOUT_FRAGMENT").Commit();
                }
            }
        }


    }
}