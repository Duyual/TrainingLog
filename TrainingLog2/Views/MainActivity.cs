using System;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using TrainingLog2.SQLiteServices;

namespace TrainingLog2.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Fetch logged workouts for today
            //If no workouts, add MainFragment
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.flContent, new MainFragment(), "HOME_FRAGMENT").Commit();
            //If workout found, add WorkoutFragment
            //SupportFragmentManager.BeginTransaction().Replace(Resource.Id.flContent, new WorkoutFragment()).Commit();

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
            SQLiteHandler sqlHandler = new SQLiteHandler();
            sqlHandler.CreateDatabase();
            sqlHandler.PrintCategories();
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_home)
            {
                Android.Support.V4.App.Fragment fragment_home = SupportFragmentManager.FindFragmentByTag("HOME_FRAGMENT");
                if (fragment_home == null || !fragment_home.IsVisible)
                {
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.flContent, new MainFragment(), "HOME_FRAGMENT").Commit();
                }
            }
            else if (id == Resource.Id.nav_workout)
            {
                Android.Support.V4.App.Fragment fragment_workout = SupportFragmentManager.FindFragmentByTag("WORKOUT_FRAGMENT");
                if (fragment_workout == null || !fragment_workout.IsVisible)
                {
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.flContent, new EditWorkoutFragment(), "WORKOUT_FRAGMENT").Commit();
                }
            }
            else if (id == Resource.Id.nav_calendar)
            {

            }
            else if (id == Resource.Id.nav_profile)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

