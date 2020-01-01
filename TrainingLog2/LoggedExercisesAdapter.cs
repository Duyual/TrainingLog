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
using TrainingLog2.Entities;
using TrainingLog2.SQLiteServices;
using static Android.Support.V7.Widget.RecyclerView;

namespace TrainingLog2
{
    public class LoggedExercisesAdapter : RecyclerView.Adapter
    {
        private List<Exercise> exercise_list;
        private Context context;
        public DateTime date;
        private LayoutInflater inflater;

        public override int ItemCount { get => exercise_list.Count; }

        public LoggedExercisesAdapter(Context context, List<Exercise> exercise_list, DateTime date)
        {
            this.inflater = LayoutInflater.From(context);
            this.date = date;
            this.context = context;
            this.exercise_list = exercise_list;
        }

        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            MyViewHolder myHolder = holder as MyViewHolder;
            myHolder.tvHeader.Text = exercise_list.ElementAt(position).Name;
            SQLiteHandler handler = new SQLiteHandler();
            var loggedSetsQuery = handler.GetLoggedSets(exercise_list.ElementAt(position).Id, date);
            var loggedCardioSetsQuery = handler.GetLoggedCardioSets(exercise_list.ElementAt(position).Id, date);
            List<Object> loggedSets_list = new List<Object>();
            foreach (var set in loggedSetsQuery)
            {
                loggedSets_list.Add(set);
            }
            foreach (var set in loggedCardioSetsQuery)
            {
                loggedSets_list.Add(set);
            }
            myHolder.rvSets.SetLayoutManager(new LinearLayoutManager(inflater.Context));
            myHolder.rvSets.SetAdapter(new LoggedSetsAdapter(inflater.Context, loggedSets_list));
        }

        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = inflater.Inflate(Resource.Layout.log_exercise, parent, false);
            ViewHolder holder = new MyViewHolder(view);
            return holder;
        }

        public class MyViewHolder : ViewHolder
        {
            public TextView tvHeader;
            public RecyclerView rvSets;
            public MyViewHolder(View itemView) : base(itemView)
            {
                tvHeader = itemView.FindViewById<TextView>(Resource.Id.tvExerciseTitle);
                rvSets = itemView.FindViewById<RecyclerView>(Resource.Id.rvSets);
            }
        }


        /*public LoggedExercisesAdapter(Context context, int textViewResourceId, List<Exercise> exercise_list, DateTime date) : base(context, textViewResourceId, exercise_list)
{
   this.exercise_list = exercise_list;
   this.context = context;
   this.date = date;
}

public override View GetView(int position, View convertView, ViewGroup parent)
{
   if (convertView == null)
   {
       LayoutInflater inflater = LayoutInflater.From(context);
       convertView = inflater.Inflate(Resource.Layout.log_exercise, null);
   }
   TextView tvHeader = convertView.FindViewById<TextView>(Resource.Id.tvExerciseTitle);
   tvHeader.Text = exercise_list.ElementAt(position).Name;
   RecyclerView rvSets = convertView.FindViewById<RecyclerView>(Resource.Id.rvSets);
   SQLiteHandler handler = new SQLiteHandler();
   var loggedSetsQuery = handler.GetLoggedSets(exercise_list.ElementAt(position).Id, date);
   List<Log_Set_Entry> loggedSets_list = new List<Log_Set_Entry>();
   foreach (var set in loggedSetsQuery)
   {
       loggedSets_list.Add(set);
   }
   rvSets.Adapter = new LoggedSetsAdapter(convertView.Context, Resource.Layout.log_exercise_set, loggedSets_list);
   return convertView;
}*/
    }
}