using Android.App;
using Android.Widget;
using Android.OS;

namespace Spinner_Toggle
{
    [Activity(Label = "Spinner_Toggle", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ToggleButton toggleButton1;
        RadioGroup radioGroup1;
        RadioButton radioButtonItalian;
        RadioButton radioButtonFrench;
        Spinner spinner1;
        ArrayAdapter adapter;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            toggleButton1 = FindViewById<ToggleButton>(Resource.Id.toggleButton1);
            radioGroup1 = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            radioButtonItalian = FindViewById<RadioButton>(Resource.Id.radioButtonItalian);
            radioButtonFrench = FindViewById <RadioButton>(Resource.Id.radioButtonFrench);

            spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);

            toggleButton1.CheckedChange += delegate
            {
                if (toggleButton1.Checked)
                {
                    Toast.MakeText(this, "true", ToastLength.Short).Show();
                    radioGroup1.Visibility = Android.Views.ViewStates.Visible;
                    spinner1.Visibility = Android.Views.ViewStates.Visible;
                }
                else if (!toggleButton1.Checked)
                {
                    Toast.MakeText(this, "false", ToastLength.Short).Show();
                    radioGroup1.Visibility = Android.Views.ViewStates.Invisible;
                    spinner1.Visibility = Android.Views.ViewStates.Invisible;
                }
            };

            radioGroup1.CheckedChange += delegate
            {
                if (radioGroup1.CheckedRadioButtonId == radioButtonItalian.Id)
                {
                    Toast.MakeText(this, "Italian Selected", ToastLength.Short).Show();
                    adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Italian,
                                                                Android.Resource.Layout.SimpleSpinnerItem);
                    adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                    spinner1.Adapter = adapter;
                }

                else
                {
                    Toast.MakeText(this, "French Selected", ToastLength.Short).Show();
                    adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.French,
                                                        Android.Resource.Layout.SimpleSpinnerItem);
                    adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                    spinner1.Adapter = adapter;
                }
            };         
        }// end onCreate()
    }//
}//

