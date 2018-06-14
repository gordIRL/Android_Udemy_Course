using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Util;

namespace FileSystemApp
{
    [Activity(Label = "FileSystemApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnEnumerate;
        Button btnReadTextFile;
        Button btnSaveToTextFile;
        EditText edtEditText1;        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnEnumerate = FindViewById<Button>(Resource.Id.btnEnumerate);
            btnReadTextFile = FindViewById<Button>(Resource.Id.btnReadTextFile);
            btnSaveToTextFile = FindViewById<Button>(Resource.Id.btnSaveToTextFile);
            edtEditText1 = FindViewById<EditText>(Resource.Id.edtEditText1);
            
            // reference to our file
            var newTextFile = Path.Combine(Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath, "newTextFile.txt");


            btnReadTextFile.Click += delegate
            {
                // reads text file
                var text = File.ReadAllText(newTextFile);
                Log.Debug("DEBUG", "Message reads: " + text);

            };


            btnSaveToTextFile.Click += delegate
            {
                // creates file if it doesn't exist
                File.AppendAllText(newTextFile, edtEditText1.Text);
                edtEditText1.Text = "";

            };


            btnEnumerate.Click += delegate
            {
                ////// don't use the internal storage - ever (?)
                ////string internalAppDirectory = Android.App.Application.Context.FilesDir.AbsolutePath;

                // get the 'external files directory'
                // this will probably be the internal non-removable storage of the phone
                string appDirectory = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;


                var newDirectory = Path.Combine(appDirectory, "myDirectory");
                // only creates a new directory if it doesn't exist
                Directory.CreateDirectory(newDirectory);

                var entriesDirs = Directory.EnumerateDirectories(appDirectory);                
                foreach (var e in entriesDirs)
                {
                    Log.Debug("debug", e);
                }


                var textFilePath = Path.Combine(appDirectory, "myTextFile.txt");
                File.CreateText(textFilePath);

                //var entries = Directory.EnumerateDirectories(appDirectory);
                var entriesFiles = Directory.EnumerateFiles(appDirectory);
                foreach (var e in entriesFiles)
                {
                    Log.Debug("debug", e);
                }
            };
        }
    }
}

