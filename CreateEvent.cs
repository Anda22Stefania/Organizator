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

namespace Organizator2
{
    [Activity(Label = "Activity1")]
    public class CreateEvent : Activity
    {
        Button createEvent, Back;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.createEvent);
            createEvent = FindViewById<Button>(Resource.Id.btnCreateEvent);
            Back = FindViewById<Button>(Resource.Id.btnBack);

            Back.Click += Back_Click;


        }

        private void Back_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Events));
            StartActivity(intent);

        }
    }
    }
