﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class Pacijent
    {
        private String ime;
        private String prezime;
        private String JMBG;
        private String email;
        private String user_name;
        private String lozinka;
        private DateTime sljedeci_termin;
        private Karton karton;

        public Pacijent()
        { }

        public Pacijent(string ime, string prezime, string jMBG, string email, string user_name, string lozinka, DateTime sljedeci_termin, Karton karton)
        {
            this.ime = ime;
            this.prezime = prezime;
            JMBG = jMBG;
            this.email = email;
            this.user_name = user_name;
            this.lozinka = lozinka;
            this.sljedeci_termin = sljedeci_termin;
            this.karton = karton;
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

        public string JMBG1
        {
            get
            {
                return JMBG;
            }

            set
            {
                JMBG = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
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

        public DateTime Sljedeci_termin
        {
            get
            {
                return sljedeci_termin;
            }

            set
            {
                sljedeci_termin = value;
            }
        }

        internal Karton Karton
        {
            get
            {
                return karton;
            }

            set
            {
                karton = value;
            }
        }
    }
}