using System;

namespace WpfApp9
{
    class Clan
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public DateTime pocetakClanarine { get; set; }


        public bool aktivan { get; set; }

        public string imeIPrezime
        {
            get
            {
                return $"{Ime} {Prezime}";
            }
        }


        public Clan(string a, string b)
        {
            Ime = a;
            Prezime = b;

        }

        public Clan()
        {


        }
        
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

    }
}
