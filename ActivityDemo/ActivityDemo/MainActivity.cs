using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ActivityDemo
{
    [Activity(Label = "ActivityDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button button1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            button1 = FindViewById<Button>(Resource.Id.button1);

            button1.Click += delegate
            {
                // code to open a new activity 
                // .net = yes //  android = wrong !!
                //var sharedActivity = new ShareActivity();

                var intent = new Intent(this.BaseContext, typeof(ShareActivity));
                intent.PutExtra("myString", "passed message");
                StartActivity(intent);

                // shareActivity when opened is now stacked on top of our MainActivity

            };


        }
    }
}

