using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class Karton
    {
        private DateTime predlozeni_termin;
        private List<string> stanje;

        public DateTime Predlozeni_termin
        {
            get
            {
                return predlozeni_termin;
            }

            set
            {
                predlozeni_termin = value;
            }
        }

        public List<string> Stanje
        {
            get
            {
                return stanje;
            }

            set
            {
                stanje = value;
            }
        }
    }
}
