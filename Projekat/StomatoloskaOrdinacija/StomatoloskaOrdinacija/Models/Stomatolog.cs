using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class Stomatolog
    {
        

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Ime
        {
            get; set;
        }

        public string Prezime
        {
            get; set;
        }

        public string User_name
        {
            get; set;
        }

        public string Lozinka
        {
            get; set;
        }

        
        public string Adresa { get; set; }
        public string Email { get; set; }
    }
}
