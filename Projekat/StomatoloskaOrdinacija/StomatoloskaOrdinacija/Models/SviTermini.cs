using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class SviTermini
    {
        private static List<Termin> svi;
        public SviTermini()
        {
            svi = new List<Termin>();
        }

        public static List<Termin> Svi
        {
            get
            {
                return svi;
            }

            set
            {
                svi = value;
            }
        }

        public void  dodajTermin(Termin t)
        {
            svi.Add(t);
        }
    }
}
