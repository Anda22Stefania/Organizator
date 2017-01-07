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
using Java.Lang;

namespace Organizator2
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView Title { get; set; }
        public TextView Description { get; set; }
    }
    class ListViewAdapter : BaseAdapter
    {
        private List<@event> AllEvents;
        private Activity activity;

     public ListViewAdapter(Activity activity, List<@event> AllEvents)
        {
            this.activity = activity;
            this.AllEvents = AllEvents;
        }

        public override int Count
        {
            get
            {
                return AllEvents.Count;
            }
        }

      

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return AllEvents[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.Row, parent, false);

            var txtTitle = view.FindViewById<TextView>(Resource.Id.Title);
            var txtDescription = view.FindViewById<TextView>(Resource.Id.Description);

            txtTitle.Text = AllEvents[position].Title;
            txtDescription.Text = AllEvents[position].Description;
            return view;
        }
    }
        
    }
