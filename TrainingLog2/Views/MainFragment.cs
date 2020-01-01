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
using TrainingLog2.Adapters;
using TrainingLog2.SQLiteServices;

namespace TrainingLog2.Views
{

    public class MainFragment : Android.Support.V4.App.Fragment, ViewPager.IOnPageChangeListener
    {
        private ViewPager viewPager;
        private ScrollableDaysPagerAdapter adapter;
        private SQLiteHandler handler;
        private bool notifyUpdate = false;
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
            View mainView = inflater.Inflate(Resource.Layout.nav_dates_main, container, false);
            ScrollableDaysPagerAdapter adapter = new ScrollableDaysPagerAdapter(this.ChildFragmentManager, DateTime.Now.Date);
            this.adapter = adapter;
            viewPager = mainView.FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = adapter;
            viewPager.AddOnPageChangeListener(this);

            TabLayout tabLayout = mainView.FindViewById<TabLayout>(Resource.Id.tabLayout);
            tabLayout.SetupWithViewPager(viewPager);

            viewPager.SetCurrentItem(1,true);
            //ChildFragmentManager.BeginTransaction().Replace(Resource.Id.flMainContent, new NoLogWorkoutFragment()).Commit();
            return mainView;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageScrollStateChanged(int state)
        {
            if (notifyUpdate && state == (int)ScrollState.Idle)
            {
                adapter.NotifyDataSetChanged();
                viewPager.SetCurrentItem(1, false);
                notifyUpdate = false;
            }
        }

        public void OnPageSelected(int position)
        {
            UpdatePages(position);
        }

        private void UpdatePages(int position)
        {
            switch (position)
            {
                case 0:
                    DateTime earlierDate = adapter.date_list.ElementAt(0).AddDays(-1);
                    adapter.exercise_list.RemoveAt(4);
                    adapter.date_list.RemoveAt(4);
                    
                    adapter.exercise_list.Insert(0, handler.GetLoggedExercises(earlierDate));
                    adapter.date_list.Insert(0, earlierDate);
                    notifyUpdate = true;
                    break;
                case 2:
                    DateTime laterDate = adapter.date_list.ElementAt(4).AddDays(1);
                    adapter.exercise_list.RemoveAt(0);
                    adapter.date_list.RemoveAt(0);
                    
                    adapter.exercise_list.Add(handler.GetLoggedExercises(laterDate));
                    adapter.date_list.Add(laterDate);
                    notifyUpdate = true;
                    break;
            }
        }
    }
}