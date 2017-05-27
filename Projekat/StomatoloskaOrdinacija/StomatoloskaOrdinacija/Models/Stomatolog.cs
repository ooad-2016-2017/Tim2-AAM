using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class Stomatolog
    {
        private String ime;
        private String prezime;
        private String user_name;
        private String lozinka;
        private List<Pacijent> mojipacijetni;

        public Stomatolog(string ime, string prezime, string user_name, string lozinka, List<Pacijent> mojipacijetni)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.user_name = user_name;
            this.lozinka = lozinka;
            this.mojipacijetni = mojipacijetni;
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }

        public string User_name
        {
            get
            {
                return user_name;
            }

            set
            {
                user_name = value;
            }
        }

        public string Lozinka
        {
            get
            {
                return lozinka;
            }

            set
            {
                lozinka = value;
            }
        }

        public List<Pacijent> Mojipacijetni
        {
            get
            {
                return mojipacijetni;
            }

            set
            {
                mojipacijetni = value;
            }
        }
    }
}
