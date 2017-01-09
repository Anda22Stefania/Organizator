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

{   

      [Activity(Label = "CreateEvent")]

    public class CreateEvent : Activity

    {

        Button createTheEvent, Back;

        EditText EventTitle, EventDescription;
        DataBase db;

        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateEvent);

            //Create the DataBase

            db = new DataBase();
            db.createDatabase();

         

            createTheEvent = FindViewById<Button>(Resource.Id.btnCreateEvent);
            Back = FindViewById<Button>(Resource.Id.btnBack);

            EventTitle = FindViewById<EditText>(Resource.Id.txtTitle);
            EventDescription = FindViewById<EditText>(Resource.Id.txtDescription);


           
         Back.Click += Back_Click;
        
            
            createTheEvent.Click += delegate
            {
                @event Event = new @event()
                {
                    Title = EventTitle.Text,
                    Description = EventDescription.Text
                };
                db.insertIntoTableEvent(Event);
                
                StartActivity(typeof(Events));
            

            };
   
        }

        private void Back_Click(object sender, EventArgs e)

        {
            StartActivity(typeof(Events));
        }

    }

}