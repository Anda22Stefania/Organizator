using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Organizator2.Database;
using Android.App;
using Android.Content;
using Android.OS;
using Newtonsoft.Json;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Organizator2
{
    [Activity(Label = "SingleEvent")]
    public class SingleEvent : Activity
    {
        Button delete, edit, finish;
        TextView EvTitle, EvDescription;
        DataBase db;
        @event Event;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Event = JsonConvert.DeserializeObject<@event>(Intent.GetStringExtra("NewEvent"));
            db = new DataBase();
            db.createDatabase();

            SetContentView(Resource.Layout.EventView);

            delete = FindViewById<Button>(Resource.Id.btnDelete);
            edit = FindViewById<Button>(Resource.Id.btnEdit);
            finish = FindViewById<Button>(Resource.Id.btnFinish);
            EvDescription = FindViewById<TextView>(Resource.Id.SingleEvDescription);
            EvTitle = FindViewById<TextView>(Resource.Id.SingleEvTitle);

            EvDescription.Text = Event.Description;
            EvTitle.Text = Event.Title;
            delete.Click += Delete_Click;
            Event.Title = EvTitle.Text;
            Event.Description = EvDescription.Text;

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            db.deleteTableEvent(Event);
            StartActivity(typeof(Events));
        }
    }
}