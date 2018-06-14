using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using System;
using System.IO;
using Java.Lang;    // 'issues with System.Threading so use Java.Lang instead??'  (ask Dhoot)
using System.Threading.Tasks;

namespace Logging_Threading_Exercise
{
    [Activity(Label = "Logging_Threading_Exercise", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnBeginLogging;
        Button btnReadLog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnBeginLogging = FindViewById<Button>(Resource.Id.btnBeginLogging);
            btnReadLog = FindViewById<Button>(Resource.Id.btnReadLog);

            var appFolder = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;
            var logFilePath = Path.Combine(appFolder, "log.txt");

            btnBeginLogging.Click += delegate
            {
                // start a new thread - so as not to run on the UUI thread - keep the UI thread responsive
                Task.Factory.StartNew(() =>
                {
                    // thread can't talk across threads to each other(?) so run on main UI thread
                    RunOnUiThread(() =>{
                        btnReadLog.Enabled = false;
                    });
                   
                    for (int i = 0; i < 5; i++)
                    {
                        var timeString = DateTime.Now.ToLongTimeString();
                        File.AppendAllText(logFilePath, timeString);
                        Thread.Sleep(1000);  // issues with System.Threading                   
                    }

                    RunOnUiThread(() => {
                        btnReadLog.Enabled = true;
                    });                    
                });
            }; // btnBeginLogging.Click


            btnReadLog.Click += delegate
            {
                var text = File.ReadAllText(logFilePath);
                Log.Debug("DEBUG", "File says: " + text);
            };

        }
    }
}

