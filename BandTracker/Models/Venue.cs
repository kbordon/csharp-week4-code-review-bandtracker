using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace BandTracker.Models
{
    public class Venue
    {
        private string _name;
        private int _id;
        // private int _capacity; TODO: further exploring

        public Venue(string title, int id = 0)
        {
            _name = title;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public string GetId()
        {
            return _id;
        }
        public void SetId(string id)
        {
            _id = id;
        }

        public override bool Equals(System.Object otherVenue)
        {
            if (!(otherVenue is Venue))
            {
                return false;
            }
            else
            {
                Venue newVenue = (Venue) otherVenue;
                return this.GetId().Equals(newVenue.GetId());
            }
        }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM venues;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Venue> GetAll()
        {
            List<Venue> allVenues = new List<Venue> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM venues;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int VenueId = rdr.GetInt32(0);
                string VenueName = rdr.GetString(1);
                Venue newVenue = new Venue(VenueName, VenueId);
                allVenues.Add(newVenue);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allVenues;
        }
    }
}
