using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using TrainingLog2.Adapters;
using TrainingLog2.Models;
using TrainingLog2.SQLiteServices;

namespace TrainingLog2.Views
{
    public class EditWorkoutFragment : Android.Support.V4.App.Fragment, Spinner.IOnItemSelectedListener
    {
        private Spinner spin;
        private SQLiteHandler handler;
        private RecyclerView rvWorkouts;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.edit_workout_main, container, false);
            spin = view.FindViewById<Spinner>(Resource.Id.spinnerRoutines);
            rvWorkouts = view.FindViewById<RecyclerView>(Resource.Id.rvWorkouts);
            handler = new SQLiteHandler();
            List<Routine> routines = new List<Routine>();
            var queryRoutines = handler.GetRoutines();
            foreach (var routine in queryRoutines)
                routines.Add(routine);
            Routine CreateNew = new Routine();
            CreateNew.Id = -1;
            CreateNew.Name = "Create new routine";
            routines.Add(CreateNew);
            spin.Adapter = new RoutinesAdapter(Context, Resource.Layout.spinner_routines_dropdown, routines);
            spin.OnItemSelectedListener = this;


            rvWorkouts.SetLayoutManager(new LinearLayoutManager(Context));
            return view;
        }

        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            Routine routine = parent.SelectedItem.GetType().GetProperty("Instance").GetValue(parent.SelectedItem) as Routine;
            if (routine.Id == -1)
            {
                Android.Support.V4.App.Fragment fragment_routine = FragmentManager.FindFragmentByTag("ADD_ROUTINE");
                if (fragment_routine == null || !fragment_routine.IsVisible)
                {
                    FragmentManager.BeginTransaction().Replace(Resource.Id.flContent, new AddRoutineFragment(), "ADD_ROUTINE").Commit();
                }
            } else
            {
                List<Workout> workout_list = new List<Workout>();
                var workout_listQuery = handler.GetWorkoutsWithRoutine(routine.Id);
                foreach (var workout in workout_listQuery)
                    workout_list.Add(workout);
                rvWorkouts.SetAdapter(new WorkoutsAdapter(Context, workout_list));
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {
            throw new NotImplementedException();
        }
    }
}