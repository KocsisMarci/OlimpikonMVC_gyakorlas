using System;
using System.Collections.Generic;
using System.Text;
using OlimpikonMVC.Models;
using OlimpikonMVC.Interfaces;
using MySql.Data.MySqlClient;
namespace OlimpikonMVC.Services
{
    public class OrszagService : ICRUD
    {

        public static MySqlConnection conn = new MySqlConnection();
        public static MySqlCommand cmd = new MySqlCommand();


        public OrszagService() {
            conn.ConnectionString = "SERVER = localhost;" +
                                    "DATABASE = olimpikonok;" +
                                    "UID=root;" +
                                    "PORT=3307;" +
                                    "PASSWORD=;";

            cmd.Connection = conn;
        }

        public string Delete(int id)
        {
            cmd.Parameters.Clear();

            conn.Open();

            cmd.CommandText = "DELETE FROM orszag Where Id=@m1";

            cmd.Parameters.AddWithValue("@m1", id);


            int sorok = cmd.ExecuteNonQuery();

            conn.Close();
            if (sorok > 0) return "Sikeres ország törlés";
            else return "Sikertelen ország törlés";

        }

        public string Insert(Orszag orszag)
        {

            cmd.Parameters.Clear();

            conn.Open();

            cmd.CommandText = "INSERT INTO orszag(Nev, Fovaros, Nepesseg) VALUES(@m1, @m2, @m3);";

            cmd.Parameters.AddWithValue("@m1", (orszag as Orszag).Nev);
            cmd.Parameters.AddWithValue("@m2", orszag.Fovaros);
            cmd.Parameters.AddWithValue("@m3", orszag.Nepesseg);


            int sorok = cmd.ExecuteNonQuery();

            conn.Close();
            if (sorok > 0) return "Sikeres ország felvitel";
            else return "Sikertelen ország felvitel";

        }

        public List<Orszag> Read()
        {
            cmd.Parameters.Clear();

            conn.Open();
            cmd.CommandText = "SELECT * FROM orszag";

            MySqlDataReader olvaso = cmd.ExecuteReader();


            List<Orszag> orszagok = new List<Orszag> { };
            while (olvaso.Read()) {
                Orszag orszag = new Orszag();

                orszag.Id= olvaso.GetInt32("Id");

                orszag.Nev= olvaso.GetString("Nev");
                orszag.Fovaros= olvaso.GetString("Fovaros");

                orszag.Nepesseg = olvaso.GetInt32("Nepesseg");
                orszagok.Add(orszag);
            }

            conn.Close();

            return orszagok;
        }

        public string Update(Orszag orszag)
        {
            cmd.Parameters.Clear();

            conn.Open();

            cmd.CommandText = "UPDATE  orszag SET Nev=@m1, Fovaros=@m2, Nepesseg=@m3 WHERE Id=@m4;";

            cmd.Parameters.AddWithValue("@m1", (orszag as Orszag).Nev);
            cmd.Parameters.AddWithValue("@m2", orszag.Fovaros);
            cmd.Parameters.AddWithValue("@m3", orszag.Nepesseg);
            cmd.Parameters.AddWithValue("@m4", orszag.Id);


            int sorok = cmd.ExecuteNonQuery();

            conn.Close();
            if (sorok > 0) return "Sikeres ország szerkesztés";
            else return "Sikertelen ország szerkesztés";


        }


        public Orszag GetById(int id) {
            cmd.Parameters.Clear();

            conn.Open();

            cmd.CommandText = "SELECT * FROM orszag WHERE Id=@m1";

            cmd.Parameters.AddWithValue("@m1", id);


            MySqlDataReader olvaso = cmd.ExecuteReader();

            Orszag orszag = new Orszag();

            if (olvaso.Read()) {

                orszag.Id = olvaso.GetInt32("Id");

                orszag.Nev = olvaso.GetString("Nev");
                orszag.Fovaros = olvaso.GetString("Fovaros");

                orszag.Nepesseg = olvaso.GetInt32("Nepesseg");

            }

            else
            {
                orszag = new Orszag();

            }

            conn.Close();
            return orszag;
        
        }

      
    }
}
