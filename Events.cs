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
    public class Events : Activity
    {
        Button addEvent, back;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Events);

            addEvent = FindViewById<Button>(Resource.Id.btnAddEvent);
            back = FindViewById<Button>(Resource.Id.btnBack);


            addEvent.Click += AddEvent_Click;
        }

        private void AddEvent_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CreateEvent));
            StartActivity(intent);
        }
    }
    }
