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
    public class CreateEvent : Activity
    {
        Button createEvent, Back;
        EditText EventTitle, EventDescription;
        public event EventHandler<OnCreateEvent> EventCreation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.createEvent);


            createEvent = FindViewById<Button>(Resource.Id.btnCreateEvent);
            Back = FindViewById<Button>(Resource.Id.btnBack);
            EventTitle = FindViewById<EditText>(Resource.Id.txtTitle);
            EventDescription = FindViewById<EditText>(Resource.Id.txtDescription);


            Back.Click += Back_Click;
            createEvent.Click += CreateEvent_Click;
           
        }

        private void CreateEvent_Click(object sender, EventArgs e)
        {
            if (EventCreation != null)
            {
                EventCreation.Invoke(this, new OnCreateEvent(EventTitle.Text, EventDescription.Text));
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            
            StartActivity(typeof(Events));

        }
    }
    }
