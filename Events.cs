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
    [Activity(Label = "Events")]
    public class Events : Activity
    {
        Button addEvent, back;
        public ListView EventsListview;
        public List<@event> AllEvents = new List<@event>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Events);
            ListViewAdapter adapter = new ListViewAdapter(this, Resource.Layout.Row, AllEvents);

            addEvent = FindViewById<Button>(Resource.Id.btnAddEvent);
            back = FindViewById<Button>(Resource.Id.btnBack);
            EventsListview = FindViewById<ListView>(Resource.Id.eventsListView);

            EventsListview.Adapter = adapter;


            addEvent.Click += AddEvent_Click;
        }

        private void AddEvent_Click(object sender, EventArgs e)
        {
           
            StartActivity(typeof(CreateEvent));
        }
    }
    }
