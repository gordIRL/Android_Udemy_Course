using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace theming_test
{
    [Activity(Label = "theming_test", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button button1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "My Themed App";

            //button1 = FindViewById<Button>(Resource.Id);
        }
    }
}

