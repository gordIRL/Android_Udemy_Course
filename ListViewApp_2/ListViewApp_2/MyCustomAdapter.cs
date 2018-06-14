using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ListViewApp_2
{
    class MyCustomAdapter : BaseAdapter<string>, ISectionIndexer
    {

        Activity activity;
        List<string> items;

        // variables for indexing  // make sure 'fastscroll' is enabled on your list (MainActivity)
        Dictionary<string, int> alphaIndex;
        string[] sections;  // array to hold all of the sections
        Java.Lang.Object[] sectionsObjects;  // array of objects to store  // need java.lang.objects for indexing !!

        public MyCustomAdapter(Activity activity, List<string> items)
        {
            this.activity = activity;
            this.items = items;

            // dictionary
            alphaIndex = new Dictionary<string, int>();
            for (int i = 0; i < items.Count; i++)
            {
                var key = items[i][0].ToString(); // pulls out the 1st character[0] in items 
                if (!alphaIndex.ContainsKey(key)) // if index doesn't already contain 'key' then add it
                    alphaIndex.Add(key, i);
            }
            // sections - array of keys
            sections = new string[alphaIndex.Keys.Count];   // number of sections
            alphaIndex.Keys.CopyTo(sections, 0);            // copy to sections at index 0
            sectionsObjects = new Java.Lang.Object[sections.Length];
            

            // sections objects (add)
            for (int i = 0; i < sections.Length; i++)
            {
                sectionsObjects[i] = new Java.Lang.String(sections[i]);
            }
        }


        public Java.Lang.Object[] GetSections()
        {
            return sectionsObjects;
        }


        public int GetPositionForSection(int section)
        {
            return alphaIndex[sections[section]];
        }


        public int GetSectionForPosition(int position)
        {
            int prevSection = 0;

            for (int i = 0; i < sections.Length; i++)
            {
                if (GetPositionForSection(i) > position)
                    break;

                prevSection = i;
            }
            return prevSection;
        }




        //int ISectionIndexer.GetPositionForSection(int sectionIndex)
        //{
        //    throw new NotImplementedException();
        //}

        //int ISectionIndexer.GetSectionForPosition(int position)
        //{
        //    throw new NotImplementedException();
        //}

        //Java.Lang.Object[] ISectionIndexer.GetSections()
        //{
        //    throw new NotImplementedException();
        //}


            //------------------------------------------------------------------------------



        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
                //view = activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                view = activity.LayoutInflater.Inflate(Resource.Layout.MyCustomRow, null);

            var item = items[position];

            if (position == 3)
                item = "(Available to subscribers only)";

            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item;
            view.FindViewById<TextView>(Resource.Id.textView1CustomRow).Text = item;

            var clock = view.FindViewById<AnalogClock>(Resource.Id.analogClock1CustomRow);
            if (position == 3)    // cell no 3 is recycle - displays as red
            {                
                clock.SetBackgroundColor(new Android.Graphics.Color(250, 50, 50));
            }
            else
            {
                clock.SetBackgroundColor(new Android.Graphics.Color(55, 55, 200));
            }
            return view;
        }

       


        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override string this[int position]
        {
            get
            {
                return items[position];
            }
        }
    }

    class MyCustomAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}