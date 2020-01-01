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
using static Android.Support.V7.Widget.RecyclerView;

namespace TrainingLog2
{
    public class LoggedSetsAdapter : RecyclerView.Adapter
    {
        private List<Object> item_list;
        private Context context;
        private LayoutInflater inflater;

        private static readonly int ITEM_TYPE_EXERCISE_SET = 1;
        private static readonly int ITEM_TYPE_EXERCISE_TRAININGMAX_SET = 2;
        private static readonly int ITEM_TYPE_CARDIO_SET = 3;

        public override int ItemCount { get => item_list.Count; }

        public LoggedSetsAdapter(Context context, List<Object> item_list)
        {
            this.context = context;
            this.item_list = item_list;
            this.inflater = LayoutInflater.From(context);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Object item = item_list.ElementAt(position);
            if (holder.GetType() == typeof(ExerciseSetViewHolder))
            {
                ExerciseSetViewHolder myHolder = holder as ExerciseSetViewHolder;
                Log_Set_Entry log = item as Log_Set_Entry;
                myHolder.bind(log);
            } else if (holder.GetType() == typeof(CardioSetViewHolder))
            {
                CardioSetViewHolder myHolder = holder as CardioSetViewHolder;
                Log_Cardio_Set_Entry log = item as Log_Cardio_Set_Entry;
                myHolder.bind(log);
            }
            //ExerciseSetViewHolder myHolder = holder as ExerciseSetViewHolder;
            //Log_Set_Entry item = item_list.ElementAt(position);
            //myHolder.tvLoggedWeight.Text = item.Weight.ToString();
            //myHolder.tvLoggedReps.Text = item.Reps.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == ITEM_TYPE_EXERCISE_SET)
            {
                View view = inflater.Inflate(Resource.Layout.log_exercise_set, parent, false);
                return new ExerciseSetViewHolder(view);
            } else
            {
                View view = inflater.Inflate(Resource.Layout.log_cardio_set, parent, false);
                return new CardioSetViewHolder(view);
            }
        }

        public override int GetItemViewType(int position)
        {
            var type = item_list.ElementAt(position).GetType();
            if (type == typeof(Log_Set_Entry))
            {
                return ITEM_TYPE_EXERCISE_SET;
            } else if (type == typeof(Log_Cardio_Set_Entry))
            {
                return ITEM_TYPE_CARDIO_SET;
            }

            return base.GetItemViewType(position);
        }

        public class ExerciseSetViewHolder : ViewHolder
        {
            public TextView tvLoggedWeight;
            public TextView tvLoggedReps;

            public ExerciseSetViewHolder(View itemView) : base(itemView)
            {
                tvLoggedWeight = itemView.FindViewById<TextView>(Resource.Id.tvLoggedWeight);
                tvLoggedReps = itemView.FindViewById<TextView>(Resource.Id.tvLoggedReps);
            }

            public void bind(Log_Set_Entry item)
            {
                Log.Info("item", item.Id.ToString());
                this.tvLoggedWeight.Text = item.Weight.ToString();
                this.tvLoggedReps.Text = item.Reps.ToString();
            }
        }

        public class CardioSetViewHolder : ViewHolder
        {
            public TextView tvLoggedDistance;
            public TextView tvLoggedType;
            public TextView tvLoggedTime;

            public CardioSetViewHolder(View itemView) : base(itemView)
            {
                tvLoggedDistance = itemView.FindViewById<TextView>(Resource.Id.tvLoggedDistance);
                tvLoggedType = itemView.FindViewById<TextView>(Resource.Id.tvLoggedType);
                tvLoggedTime = itemView.FindViewById<TextView>(Resource.Id.tvLoggedTime);
            }

            public void bind(Log_Cardio_Set_Entry item)
            {
                tvLoggedDistance.Text = item.Distance.ToString();
                tvLoggedType.Text = item.Type;
                string timeString = "";
                if (item.Hours > 0)
                {
                    timeString += item.Hours.ToString() + ":";
                    if (item.Minutes > 9)
                        timeString += item.Minutes.ToString() + ":";
                    else
                        timeString += "0" + item.Minutes.ToString() + ":";
                    if (item.Seconds > 9)
                        timeString += item.Seconds.ToString();
                    else
                        timeString += "0" + item.Hours.ToString();
                }
                else if (item.Minutes > 0)
                {
                    timeString += item.Minutes.ToString() + ":";
                    if (item.Seconds > 9)
                        timeString += item.Seconds.ToString();
                    else
                        timeString += "0" + item.Hours.ToString();
                }
                else
                {
                    timeString += item.Seconds.ToString();
                }
                this.tvLoggedTime.Text = timeString;
            }
        } 

        /*public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = LayoutInflater.From(context);
                convertView = inflater.Inflate(Resource.Layout.log_exercise_set, null);
            }
            Log_Set_Entry item = item_list.ElementAt(position);
            TextView tvLoggedWeight = convertView.FindViewById<TextView>(Resource.Id.tvLoggedWeight);
            TextView tvLoggedReps = convertView.FindViewById<TextView>(Resource.Id.tvLoggedReps);
            tvLoggedWeight.Text = item.Weight.ToString();
            tvLoggedReps.Text = item.Reps.ToString();
            return convertView;
        }*/

    }
}