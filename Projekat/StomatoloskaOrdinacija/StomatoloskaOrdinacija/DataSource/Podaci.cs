using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.DataSource
{
    public class Podaci
    {
        #region Pacijent - kreiranje testnih podataka
        private static List<Pacijent> _pacijenti = new List<Pacijent>()
        {
            new Pacijent()
            {
               // new Pacijent("Mirza", "Ceman", "1343214", "mc@hotmail.com", "mirza", "sifra", DateTime.Today, new Karton(DateTime.Today, new List<string>()));
            }
        };

    }
    #endregion
}
