using System;
using System.Collections.Generic;
using System.Text;

namespace OlimpikonMVC.Models
{
    public class Orszag:Tabla
    {
        public string Nev { get; set; }
        public string Fovaros { get; set; }

        public int Nepesseg { get; set; }

        


        public override string ToString()
        {

            if (this.Nev == "Nincs találat") {
                return "Nincs ilyen azonosítójú ország";
            }

            else
            {
                return $"Ország id: {Id}, Név: {Nev}, Főváros: {Fovaros}, Népesség: {Nepesseg}";
            }
        }
    }
}
