using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TrainingLog2.Entities;

namespace TrainingLog2
{
    public class RoutinesAdapter : ArrayAdapter<Routine>
    {
        private List<Routine> routines;
        public RoutinesAdapter(Context context, int textViewResourceId, List<Routine> routines) : base(context, textViewResourceId, routines)
        {
            this.routines = routines;
            Log.Info("count", routines.Count.ToString());
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = LayoutInflater.From(Context);
            convertView = inflater.Inflate(Resource.Layout.spinner_routines_dropdown, parent, false);
            TextView tvCurrItem = convertView.FindViewById<TextView>(Resource.Id.tvCurrItem);
            tvCurrItem.Text = routines.ElementAt(position).Name;
            return convertView;
        }

        public override int Count => routines.Count;

        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = LayoutInflater.From(Context);
            convertView = inflater.Inflate(Resource.Layout.spinner_routines_item, parent, false);
            TextView tvCurrItem = convertView.FindViewById<TextView>(Resource.Id.tvCurrItem);
            tvCurrItem.Text = routines.ElementAt(position).Name;
            return convertView;
        }

    }
}