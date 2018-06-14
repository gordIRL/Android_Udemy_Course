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

namespace ActivityDemo
{
    [Activity(Label = "ShareActivity")]
    public class ShareActivity : Activity
    {
        Button button1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewActivityLayout);

            try
            {
                var myString = Intent.GetStringExtra("myString");  // be careful here - no compile-time checking on this !
                Log.Debug("Debug", "Message: " + myString);
            }
            catch
            {          }
            
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += delegate
            {
                // re-enable backbutton functionality, ??  after user has registered
                base.OnBackPressed();
            };
        }

        public override void OnBackPressed()
        {
            // disable back button functionality
            //base.OnBackPressed();
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug("debug", "PAUSE");
           // SaveState();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug("debug", "DESTROY");
            //SaveState();
        }

        //// Method to check has data been saved & if not then save data 
        //  - this method is placed in OnPause() & OnResume() above
        //void SaveState()
        //{
        //    if (!SavedState)
        //    {
        //        // save data
        //    }
        //}

    }
}