using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Android.Views.Animations;
using Android.Content;
using Android.Animation;
using Android.Util;

namespace xml_transition
{
    [Activity(Label = "xml_transition", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button button1;
        Button button2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView1);

            button1.Click += delegate
            {   /*             
                Animation myAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.my_animation);
                ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView1);
                imageView.StartAnimation(myAnimation);
                */

                //// move on the 'X' cordinate
                var animation = ObjectAnimator.OfFloat(imageView, "X", new float[] { imageView.GetX(), imageView.GetX() + 100 });
                //// adjust the image transparenct
                //var animation = ObjectAnimator.OfFloat(imageView, "alpha", new float[] { imageView.Alpha, 0.1f });

                animation.SetDuration(1500);

                animation.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                animation.RepeatCount = 30;
                animation.Start();

                // animations don't are indepentdent & don't delay any other code from running
                // log.debug below runs immediately, even though the animation hasn't finished
                Log.Debug("debug", "my message - occurs during the animation - NOT after it  !!");

            };

            button2.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Activity2));
                StartActivity(intent);
            };
        }
    }
}

