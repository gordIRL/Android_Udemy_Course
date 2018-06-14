using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Content.Res;
using Android.Util;

namespace Translate_Images_StreamReader
{
    [Activity(Label = "Translate_Images_StreamReader", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button button1;
        Button button2;
        ImageView imageView1;
        TextView textView1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            imageView1 = FindViewById<ImageView>(Resource.Id.imageView1);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView1.Visibility = Android.Views.ViewStates.Gone;

            // Change language settings on phone to see english or french text on buttons!!
            button1.Text = GetString(Resource.String.button1);
            button2.Text = GetString(Resource.String.button2);

            button1.Click += delegate
            {
                imageView1.Visibility = Android.Views.ViewStates.Gone;
                textView1.Visibility = Android.Views.ViewStates.Visible;

                string content;
                AssetManager assets = this.Assets;

                using (StreamReader sr = new StreamReader(assets.Open("MyTestTextFile.txt")))
                {
                    content = sr.ReadToEnd();
                }
                Log.Debug("MyMessage", content);
                textView1.Text = content;

            };

            button2.Click += delegate
            {
                imageView1.Visibility = Android.Views.ViewStates.Visible;
                textView1.Visibility = Android.Views.ViewStates.Gone;
            };
        }
    }
}

