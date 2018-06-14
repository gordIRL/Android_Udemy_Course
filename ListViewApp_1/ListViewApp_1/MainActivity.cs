using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ListViewApp_1
{
    [Activity(Label = "ListViewApp_1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView listView1;
        List<string> myList = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listView1 = FindViewById<ListView>(Resource.Id.listView1);

            // set up list           
            for (int i = 0; i < 20; i++)
            {
                myList.Add("Item no: " + i.ToString());
            }

            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myList);
            listView1.Adapter = adapter;

            listView1.ItemClick += ListView1_ItemClick;
        }


        private void ListView1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, $"You selected item no: {e.Position} \nwhich is \n{myList[e.Position]}", ToastLength.Short).Show();
        }
    }//
}//

