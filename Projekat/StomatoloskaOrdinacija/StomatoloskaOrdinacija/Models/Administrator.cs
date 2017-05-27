using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Models
{
    public class Administrator
    {
        private String user_name;
        private String lozinka;

        public Administrator(string user_name, string lozinka)
        {
            this.user_name = user_name;
            this.lozinka = lozinka;
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
    }
}
