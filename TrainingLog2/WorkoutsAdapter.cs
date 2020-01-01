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
using static Android.Support.V7.Widget.RecyclerView;
using static TrainingLog2.SQLiteServices.SQLiteHandler;

namespace TrainingLog2
{
    public class WorkoutsAdapter : RecyclerView.Adapter
    {
        public override int ItemCount => workout_list.Count;

        private List<Workout> workout_list;
        private Context context;
        private LayoutInflater inflater;
        private SQLiteHandler handler;

        public WorkoutsAdapter(Context context, List<Workout> workout_list)
        {
            this.workout_list = workout_list;
            this.context = context;
            this.inflater = LayoutInflater.From(context);
            this.handler = new SQLiteHandler();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            WorkoutViewHolder myHolder = holder as WorkoutViewHolder;
            myHolder.tvWorkoutTitle.Text = workout_list.ElementAt(position).Name;

            List<ExerciseSets> exerciseSets = handler.GetExercisesNSetsWorkout(workout_list.ElementAt(position).Id);

            if (exerciseSets.Count > 0)
            {
                myHolder.rvExercises.SetLayoutManager(new LinearLayoutManager(myHolder.rvExercises.Context));
                myHolder.rvExercises.SetAdapter(new ExerciseNSetsAdapter(myHolder.rvExercises.Context, exerciseSets));
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View workoutView = inflater.Inflate(Resource.Layout.log_workout, parent, false);
            ViewHolder holder = new WorkoutViewHolder(workoutView);
            return holder;
        }
    }

    public class WorkoutViewHolder : ViewHolder
    {
        public TextView tvWorkoutTitle;
        public RecyclerView rvExercises;

        public WorkoutViewHolder(View itemView) : base(itemView)
        {
            tvWorkoutTitle = itemView.FindViewById<TextView>(Resource.Id.tvWorkoutTitle);
            rvExercises = ItemView.FindViewById<RecyclerView>(Resource.Id.rvSets);
        }
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}