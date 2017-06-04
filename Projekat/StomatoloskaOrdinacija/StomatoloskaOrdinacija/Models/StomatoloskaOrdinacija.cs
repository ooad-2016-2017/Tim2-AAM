using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class StomatoloskaOrdinacija
    {
        private String naziv;
        private Administrator admin;
        private List<Pacijent> pacijenti;
        private List<Stomatolog> stomatolozi;

        public StomatoloskaOrdinacija(string naziv, Administrator admin, List<Pacijent> pacijenti, List<Stomatolog> stomatolozi)
        {
            this.Naziv = naziv;
            this.Admin = admin;
            this.Pacijenti = pacijenti;
            this.Stomatolozi = stomatolozi;
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

        public Administrator Admin
        {
            get
            {
                return admin;
            }

            set
            {
                admin = value;
            }
        }

        public List<Pacijent> Pacijenti
        {
            get
            {
                return pacijenti;
            }

            set
            {
                pacijenti = value;
            }
        }

        public List<Stomatolog> Stomatolozi
        {
            get
            {
                return stomatolozi;
            }

            set
            {
                stomatolozi = value;
            }
        }
    }
}
