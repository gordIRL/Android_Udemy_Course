using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Threading;
//using Java.Lang;   - this didn't work for threading (used the option above)

namespace SlowTextMover
{
    [Activity(Label = "SlowTextMover", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnTransport;
        TextView textView1;
        EditText edtText1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnTransport = FindViewById<Button>(Resource.Id.btnTransport);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            edtText1 = FindViewById<EditText>(Resource.Id.edtText1);

            btnTransport.Click += delegate {
                
                textView1.Text = "";

                Task.Factory.StartNew(() => {
                    while (edtText1.Text.Length > 0)  {
                        RunOnUiThread(() => {                           
                            textView1.Text += edtText1.Text.Substring(0, 1);                            
                            edtText1.Text = edtText1.Text.Substring(1);

                            if (edtText1.Text.Length < 1)
                            {
                                Toast.MakeText(this, "All should be finished now!", ToastLength.Short).Show();
                            }                                
                        }); // end RunOnUiThread

                        Thread.Sleep(1000);                       
                    }// end while                      
                }); // end Task.Factory
            };  // end btnTransport>Click
        }// end oncreate()
    }//
}//

