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
    class ListViewAdapter : BaseAdapter<@event>
    {
        private List<@event> AllEvents;
        private Context Context;
        private int Layout;

        //constructor
        public ListViewAdapter (Context context,int layout, List<@event> allevents)
        {
            Context = context;
            AllEvents = allevents;
            Layout = layout;
        }


        public override @event this[int position]
        {
            get
            {
                return AllEvents[position];
            }
        }

        public override int Count
        {
            get
            {
                return AllEvents.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(Context).Inflate(Resource.Layout.Row, null, false);
            }

            row.FindViewById<TextView>(Resource.Id.createTitle).Text = AllEvents[position].Title;
            row.FindViewById<TextView>(Resource.Id.createDescription).Text = AllEvents[position].Description;
            return row;
        }
    }
}