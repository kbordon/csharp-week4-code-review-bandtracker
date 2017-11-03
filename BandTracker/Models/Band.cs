using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BandTracker.Models
{
    public class Band
    {
        private string _name;
        private int _id;
        // private int _popularity; TODO: further exploring

        public Band(string title, int id = 0)
        {
            _name = title;
            _id = id;
            // _poularity = popularity;
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

        public override bool Equals(System.Object otherBand)
        {
            if (!(otherBand is Band))
            {
                return false;
            }
            else
            {
                Band newBand = (Band) otherBand;
                return this.GetId().Equals(newBand.GetId());
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
            cmd.CommandText = @"DELETE FROM bands;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Band> GetAll()
        {
            List<Band> allBands = new List<Band> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM bands;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int BandId = rdr.GetInt32(0);
                string BandName = rdr.GetString(1);
                Band newBand = new Band(BandName, BandId);
                allBands.Add(newBand);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allBands;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO bands (name) VALUES (@BandName);";
            cmd.Parameters.Add(new MySqlParameter("@BandName", this.GetName()));
            cmd.ExecuteNonQuery();
            this.SetId((int) cmd.LastInsertedId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Band Find(int inputId)
        {
                MySqlConnection conn = DB.Connection();
                conn.Open();

                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = "SELECT * FROM bands WHERE id = @SearchId;";
                cmd.Parameters.Add(new MySqlParameter("@SearchId", inputId));

                int bandId = 0;
                string bandName = "";

                var rdr = cmd.ExecuteReader() as MySqlDataReader;
                while (rdr.Read())
                {
                    bandId = rdr.GetInt32(0);
                    bandName = rdr.GetString(1);
                }

                Band foundBand = new Band(bandName, bandId);
                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
                return foundBand;
        }

        public void UpdateBand(string updateName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE bands SET name = @NewName WHERE id = @SearchId;";

            cmd.Parameters.Add(new MySqlParameter("@SearchId", this.GetId()));
            //name
            cmd.Parameters.Add(new MySqlParameter("@NewName", updateName));
            //city TODO
            // cmd.Parameters.Add(new MySqlParameter("@NewCity", updateCity));
            //capacity TODO
            // cmd.Parameters.Add(new MySqlParameter("@NewCapacity", updateCapacity));

            cmd.ExecuteNonQuery();
            this.SetName(updateName);
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
            cmd.CommandText = "DELETE FROM bands WHERE id = @SearchId;";
            cmd.Parameters.Add(new MySqlParameter("@SearchId", this.GetId()));
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
