using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class Termin
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool Zauzet
        {
            get; set;
        }

        public DateTime Datum
        {
            get; set;
        }

        public string Novosti
        {
            get; set;
        }

        public int idPacijenta
        {
            get; set;
        }

        public int idStomatologa
        {
            get; set;
        }


        public string toStringMoja()
        {
            var dan = this.Datum.Day;
            string dans = dan.ToString();
            var mjesec = this.Datum.Month;
            string mjesecs = mjesec.ToString();
            var godina = this.Datum.Year;
            string godinas = godina.ToString();
            var sat = this.Datum.Hour;
            string sats = sat.ToString();
            var minuta = this.Datum.Minute;
            string minutas = minuta.ToString();
            string s = dans + "." + mjesecs+ "." + godinas+ ", u " + sats + " sati i " + minutas + " minuta.";
            return s;
        }

        public string datumToString()
        {
            var dan = this.Datum.Day;
            string dans = dan.ToString();
            var mjesec = this.Datum.Month;
            string mjesecs = mjesec.ToString();
            var godina = this.Datum.Year;
            string godinas = godina.ToString();
            string s = dans + "." + mjesecs + "." + godinas;
            return s;
        }
        public string vrijemeToString()
        {
            var sat = this.Datum.Hour;
            string sats = sat.ToString();
            var minuta = this.Datum.Minute;
            string minutas = minuta.ToString();
            string s = sats + " sati i " + minutas + " minuta.";
            return s;
        }
    }
}
