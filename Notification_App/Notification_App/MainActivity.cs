using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Notification_App
{
    [Activity(Label = "Notification_App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button button1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            button1 = FindViewById<Button>(Resource.Id.button1);

            Notification.Builder builder = new Notification.Builder(this);
            const int notificationID = 0;
            NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            bool firstNotificationSent = false;


            button1.Click += delegate
            {
                if (!firstNotificationSent)
                {
                    // Notifications at a minimum have:   icon, title, message & time
                    builder.SetContentText("My app notification");
                    builder.SetContentText("Hi there this is a notification(obiviously)");
                    builder.SetSmallIcon(Resource.Mipmap.ic_home_black_24dp);  // see android documentation for icon sizes

                    // this is deprecated !!!!!!
                    builder.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Lights);

                    Notification notification = builder.Build();

                    // service that displays the notification
                    notificationManager.Notify(notificationID, notification);

                    firstNotificationSent = true;
                }
                else
                {
                    builder.SetContentTitle("Update to notification");
                    builder.SetContentText("Stop pressing the button!");

                    Notification notif = builder.Build();
                    notificationManager.Notify(notificationID, notif);
                }
            };
        }
    }
}

