using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TrainingLog2.Views;
using TrainingLog2.Models;
using TrainingLog2.SQLiteServices;

namespace TrainingLog2.Adapters
{
    public class ScrollableDaysPagerAdapter : FragmentStatePagerAdapter
    {
        private SQLiteHandler handler;
        public DateTime date;
        public List<List<Exercise>> exercise_list;
        public List<DateTime> date_list;
        public int positionNum = 1;

        public ScrollableDaysPagerAdapter(FragmentManager fm, DateTime date) : base(fm)
        {
            this.handler = new SQLiteHandler();
            this.date = date;
            this.exercise_list = new List<List<Exercise>>();
            this.date_list = new List<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                date_list.Add(date.Date.AddDays(i-2));
                exercise_list.Add(handler.GetLoggedExercises(date_list.ElementAt(i)));
            }

        }

        public override int Count { get => 3; }

        public override Fragment GetItem(int position)
        {
            if (exercise_list.ElementAt(position+positionNum).Count == 0)
                return new NoLogWorkoutFragment(date_list.ElementAt(position+positionNum));
            else
                return new LogWorkoutFragment(exercise_list.ElementAt(position+positionNum), date_list.ElementAt(position+positionNum));
        }

        public override int GetItemPosition(Java.Lang.Object @object)
        {
            return PagerAdapter.PositionNone;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            string title = GetItem(position).ToString();
            return new Java.Lang.String(title);
        }
    }
}