using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using TrainingLog2.Entities;
using TrainingLog2.SQLiteServices;

namespace TrainingLog2.Fragments
{
    public class LogWorkoutFragment : Android.Support.V4.App.Fragment
    {
        private List<Exercise> exercise_list;
        public DateTime date;

        public LogWorkoutFragment(List<Exercise> exercise_list, DateTime date)
        {
            this.exercise_list = exercise_list;
            this.date = date;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View mainView = inflater.Inflate(Resource.Layout.content_exercise_main, container, false);
            RecyclerView rvExercises = mainView.FindViewById<RecyclerView>(Resource.Id.rvExercises);
            rvExercises.SetLayoutManager(new LinearLayoutManager(container.Context));
            rvExercises.SetAdapter(new LoggedExercisesAdapter(container.Context, exercise_list, date));
            return mainView;
        }

        public override string ToString()
        {
            return date.ToString("ddd, dd MMM");
        }
    }
}