using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Organizator2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Organizator2

{   //AddEvent handler

    public class OnCreateEvent : EventArgs

    {



        private string title, description;



        public string EvTitle

        {

            get { return title; }

            set { title = value; }



        }



        public string EvDescription

        {



            get { return description; }

            set { description = value; }



        }

        public OnCreateEvent(string title, string descritpion) : base()

        {

            EvTitle = title;

            EvDescription = description;

        }

    }





    [Activity(Label = "CreateEvent")]

    public class MyEvents : Activity

    {

        

        EditText EventTitle, EventDescription;
        Button back;
        ListView EventsListview;
        Button AddEvent;
        List<@event> AllEvents = new List<@event>();
        DataBase db;

        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventsScreen);

            //Create the DataBase

            db = new DataBase();
            db.createDatabase();

            EventsListview = FindViewById<ListView>(Resource.Id.eventsListView);



            back = FindViewById<Button>(Resource.Id.back);
            AddEvent = FindViewById<Button>(Resource.Id.btnAddEvent);
            EventTitle = FindViewById<EditText>(Resource.Id.txtTitle);
            EventDescription = FindViewById<EditText>(Resource.Id.txtDescription);






            AddEvent.Click += delegate
            {
                @event Event = new @event()
                {
                    Title = EventTitle.Text,
                    Description = EventDescription.Text
                };
                db.insertIntoTableEvent(Event);
                LoadData();
                

            };
            back.Click += (object sender, System.EventArgs e) =>

            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            LoadData();
        }

        public void LoadData()
        {
            AllEvents = db.selectTableEvent();
            var adapter = new ListViewAdapter(this, AllEvents);

            EventsListview.Adapter = adapter;
        }





    }

}