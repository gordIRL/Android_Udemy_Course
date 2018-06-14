using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace xml_transition
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        Button btnAct2_startTransition;
        ImageView imageView_act_2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity2_layout);

            // Create your application here
            btnAct2_startTransition = FindViewById<Button>(Resource.Id.btnAct2_startTransition);

            btnAct2_startTransition.Click += delegate
            {
                TransitionDrawable drawable = (TransitionDrawable)FindViewById<ImageView>(Resource.Id.imageView_act_2).Drawable;
                drawable.StartTransition(1500);
            };
        }
    }
}