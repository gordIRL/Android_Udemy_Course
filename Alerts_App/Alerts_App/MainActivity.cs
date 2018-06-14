using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace Alerts_App
{
    [Activity(Label = "Alerts_App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnAlertDialog;
        Button btnListDialog;
        Button btnToast;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnAlertDialog = FindViewById<Button>(Resource.Id.btnAlertDialog);
            btnListDialog = FindViewById<Button>(Resource.Id.btnListDialog);
            btnToast = FindViewById<Button>(Resource.Id.btnToast);


            btnAlertDialog.Click += delegate
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetMessage("Hi there!");
                builder.SetTitle("My Title");

                // positive 1st - so it is on the left of the screen, where user is used to seeing it!
                builder.SetPositiveButton("OK", (sender, e)=> {
                    Log.Debug("dbg", "OK clicked");
                });

                builder.SetNegativeButton("Cancel", (sender, e) =>
                {
                    Log.Debug("dbg", "Cancel clicked");
                });

                // builder.SetNeutralButton.........

                var alert = builder.Create();
                alert.Show();
            };


            btnListDialog.Click += delegate
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Choose one: ");

                var items = new string[] { "piza", "pasta", "diet coke" };

                builder.SetItems(items, (sender, e) =>
                {
                    var index = e.Which;
                    Log.Debug("DEBUG", items[index]);
                });
                               

                builder.SetNegativeButton("Cancel", (sender, e) =>
                {
                    Log.Debug("dbg", "Cancel clicked");
                });
                
                var alert = builder.Create();
                alert.Show();
            };

            btnToast.Click += delegate
            {
                Toast.MakeText(this, "This is a toast", ToastLength.Long).Show();
            };
        }
    }
}

