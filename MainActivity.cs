using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Organizator2
{
    [Activity(Label = "Organizator2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button Home, Events, Grades;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Home = FindViewById<Button>(Resource.Id.btnHome);
            Events = FindViewById<Button>(Resource.Id.btnEvents);
            Grades = FindViewById<Button>(Resource.Id.btnGrades);

            Events.Click += Events_Click;



        }

        private void Events_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Events));
            StartActivity(intent);
        }
    }
    }


