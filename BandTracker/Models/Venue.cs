using System;
using System.Collections.Generic;
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
        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
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
            cmd.CommandText = @"DELETE FROM gigs; DELETE FROM venues;";
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

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            // Ensures input is capitalized
            string name = this.GetName();
            string[] splitName = name.Split();
            List<String> newName = new List<String>{};
            foreach (string word in splitName)
            {
                char[] splitWord = word.ToCharArray();
                if (Char.IsLetter(splitWord[0]) && Char.IsLower(splitWord[0]))
                {
                    splitWord[0] = Char.ToUpper(splitWord[0]);
                }
                string combinedWord = new string(splitWord);
                newName.Add(combinedWord);
            }
            string capitalizedName = String.Join(" ", newName.ToArray());

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO venues (name) VALUES (@VenueName);";
            cmd.Parameters.Add(new MySqlParameter("@VenueName", capitalizedName));
            cmd.ExecuteNonQuery();
            this.SetName(capitalizedName);
            this.SetId((int) cmd.LastInsertedId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Venue Find(int inputId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "SELECT * FROM venues WHERE id = @SearchId;";
            cmd.Parameters.Add(new MySqlParameter("@SearchId", inputId));

            int venueId = 0;
            string venueName = "";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                venueId = rdr.GetInt32(0);
                venueName = rdr.GetString(1);
            }
            Venue foundVenue = new Venue(venueName, venueId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundVenue;
        }

        public void UpdateVenue()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE venues SET name = @NewName WHERE id = @SearchId;";

            cmd.Parameters.Add(new MySqlParameter("@SearchId", this.GetId()));
            //name
            cmd.Parameters.Add(new MySqlParameter("@NewName", this.GetName()));
            //city TODO
            // cmd.Parameters.Add(new MySqlParameter("@NewCity", updateCity));
            //capacity TODO
            // cmd.Parameters.Add(new MySqlParameter("@NewCapacity", updateCapacity));

            cmd.ExecuteNonQuery();
            // this.SetName(updateName);
            // this.SetCity(updateCity); TODO
            // this.SetCapacity(updateCapacity); TODO

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "DELETE FROM venues WHERE id = @SearchId; DELETE FROM gigs WHERE venue_id = @SearchId;";
            cmd.Parameters.Add(new MySqlParameter("@SearchId", this.GetId()));
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void AddBand(Band newBand)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "INSERT INTO gigs (band_id, venue_id) VALUES (@BandId, @VenueId);";
            cmd.Parameters.Add(new MySqlParameter("@BandId", newBand.GetId()));
            cmd.Parameters.Add(new MySqlParameter("@VenueId", this.GetId()));
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Band> GetAllBands()
        {
            List<Band> venueBands = new List<Band>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "SELECT bands.* FROM gigs JOIN bands ON gigs.band_id = bands.id WHERE venue_id = @VenueId;";
            cmd.Parameters.Add(new MySqlParameter("@VenueId", GetId()));
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Band venueBand = new Band(name, id);
                venueBands.Add(venueBand);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return venueBands;
        }
    }
}
