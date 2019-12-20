using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using Countr.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Content.PM;

namespace Countr.Droid.Views
{
    //[Activity(Label = "Add a new counter", LaunchMode =  LaunchMode.SingleTask)] // Set as single task so that when this activity is shown, all activities above it in the stack are cleared
    [Activity(Label = "Add a new counter")] // to return the activity to standard mode, comment out the line above and uncomment this line
    public class View2 : MvxAppCompatActivity<ViewModel2>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.view_2);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    ViewModel.CancelCommand.Execute(null);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.new_counter_menu);
            return true;
        }
    }
}