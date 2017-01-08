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
using SQLite;
using Android.Util;

namespace Organizator2.Database
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDatabase()
        {
            try {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Events.db")))
                {
                    connection.CreateTable<@event>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool insertIntoTableEvent(@event Event)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Events.db")))
                {
                    connection.Insert(Event);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<@event> selectTableEvent()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Events.db")))
                {
                    return connection.Table<@event>().ToList();
                   
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool updateTableEvent(@event Event)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Events.db")))
                {
                    connection.Query<@event>("UPDATE @event set Title=?,Description=? Where Id=?",Event.Title,Event.Description,Event.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool deleteTableEvent(@event Event)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Events.db")))
                {
                    connection.Delete(Event);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool selectQueryTableEvent(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Events.db")))
                {
                    connection.Query<@event>("SELECT * FROM @event Where Id=?",Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}