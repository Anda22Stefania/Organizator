using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;

using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Organizator2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Organizator2

{  
    [Activity(Label = "Events")]

    public class Events : Activity

    {
      
        ListView EventsListview;
        Button addEvent;
        List<@event> AllEvents = new List<@event>();
        DataBase db;

        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Events);

            //Create the DataBase

            db = new DataBase();
            db.createDatabase();

            EventsListview = FindViewById<ListView>(Resource.Id.eventsListView);
            addEvent = FindViewById<Button>(Resource.Id.btnAddEvent);


            addEvent.Click += AddEvent_Click;
        
           

            EventsListview.ItemClick += EventsListview_ItemClick;

            LoadData();
        }


        private void EventsListview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var EventTitle = e.View.FindViewById<TextView>(Resource.Id.Title);
            var EventDescription = e.View.FindViewById<TextView>(Resource.Id.Description);
            @event newEvent = new @event()
            {   
                Title = EventTitle.Text,
                Description = EventDescription.Text,
               
            };
            Intent intent = new Intent(this, typeof(SingleEvent));
            intent.PutExtra("NewEvent", JsonConvert.SerializeObject(newEvent));
            this.StartActivity(intent);
            this.Finish();
        }







        private void AddEvent_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CreateEvent));
        }

        public void LoadData()
        {
            AllEvents = db.selectTableEvent();
            var adapter = new ListViewAdapter(this, AllEvents);

            EventsListview.Adapter = adapter;
        }





    }

}