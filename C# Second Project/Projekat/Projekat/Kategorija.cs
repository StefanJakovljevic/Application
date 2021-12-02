using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Kategorija
    {
        private int id;
        private String ime_kategorije;

        public Kategorija(int id, string ime_kategorije)
        {
            this.id = id;
            this.ime_kategorije = ime_kategorije;
        }

        public Kategorija()
        {
            this.id = 0;
            this.ime_kategorije = "";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Id { get => id; set => id = value; }
        public String Ime_kategorije { get => ime_kategorije; set => ime_kategorije = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
