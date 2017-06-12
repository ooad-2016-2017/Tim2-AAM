using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class Karton
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
    }
}
