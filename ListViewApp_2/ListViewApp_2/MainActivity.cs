using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ListViewApp_2
{
    [Activity(Label = "ListViewApp_2", MainLauncher = true)]
    public class MainActivity : Activity
    {
        List<string> myList = new List<string>();
        ListView listView1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listView1 = FindViewById<ListView>(Resource.Id.listView1);

            //populate list
            for (int i = 10; i < 100; i++)
            {
                myList.Add(i.ToString() + " Item thingy");
            }

            // enable 'fast-scrolling'
            listView1.FastScrollEnabled = true;

            MyCustomAdapter adapter = new MyCustomAdapter(this, myList);
            listView1.Adapter = adapter;



        }// onCreate
    }//
}//

