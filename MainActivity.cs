using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Support.V7.App;

namespace Organizator2
{
    [Activity(Label = "Organizator2",Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        Button Home, Events, Grades;
        
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

           

              Home = FindViewById<Button>(Resource.Id.btnHome);
              Events = FindViewById<Button>(Resource.Id.btnEvents);
              Grades = FindViewById<Button>(Resource.Id.btnGrades);
            


            Events.Click += (object sender, System.EventArgs e)=>

        {
           
            StartActivity(typeof(Events));
        };

        }
    }
}



