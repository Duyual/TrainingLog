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
using static Android.Support.V7.Widget.RecyclerView;
using static TrainingLog2.SQLiteServices.SQLiteHandler;

namespace TrainingLog2.Adapters
{
    public class ExerciseNSetsAdapter : RecyclerView.Adapter, LinearLayout.IOnClickListener
    {
        private List<ExerciseSets> exerciseSets;
        private LayoutInflater inflater;
        private Context context;
        public override int ItemCount => this.exerciseSets.Count;

        public ExerciseNSetsAdapter(Context context, List<ExerciseSets> exerciseSets)
        {
            this.context = context;
            this.exerciseSets = exerciseSets;
            this.inflater = LayoutInflater.From(context);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ExerciseSetsViewHolder viewHolder = holder as ExerciseSetsViewHolder;
            ExerciseSets set = exerciseSets.ElementAt(position);
            viewHolder.tvExerciseTitle.Text = set.Name;
            viewHolder.tvNSets.Text = set.Count.ToString() + (set.Count > 1 ? " sets" : " set");
            viewHolder.llExercise.SetOnClickListener(this);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = inflater.Inflate(Resource.Layout.exercise_nsets, parent, false);
            ViewHolder holder = new ExerciseSetsViewHolder(view);
            return holder;
        }

        public void OnClick(View v)
        {
            Dialog dialog = new Dialog(context);
            dialog.SetTitle("trori");
            dialog.Show();
        }

        public class ExerciseSetsViewHolder : ViewHolder
        {
            public TextView tvExerciseTitle;
            public TextView tvNSets;
            public LinearLayout llExercise;
            public ExerciseSetsViewHolder(View itemView) : base(itemView)
            {
                tvExerciseTitle = itemView.FindViewById<TextView>(Resource.Id.tvExerciseTitle);
                tvNSets = itemView.FindViewById<TextView>(Resource.Id.tvExerciseSets);
                llExercise = itemView.FindViewById<LinearLayout>(Resource.Id.llExercise);
            }
        }

    }
}