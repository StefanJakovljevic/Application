using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Proizvodi
    {
        private int id;
        private int kod_proizvoda;
        private String ime_proizvoda;
        private int cena;
        private String kategorija;

        public Proizvodi(int id, int kod_proizvoda, string ime_proizvoda, int cena, string kategorija)
        {
            this.id = id;
            this.kod_proizvoda = kod_proizvoda;
            this.ime_proizvoda = ime_proizvoda;
            this.cena = cena;
            this.kategorija = kategorija;
        }

        public Proizvodi()
        {
            this.id = 0;
            this.kod_proizvoda = 0;
            this.ime_proizvoda = "";
            this.cena = 0;
            this.kategorija = "";
        }

        public int Id { get => id; set => id = value; }

        public int Kod_proizvoda { get => kod_proizvoda; set => kod_proizvoda = value; }

        public String Ime_proizvoda { get => ime_proizvoda; set => ime_proizvoda = value; }

        public int Cena { get => cena; set => cena = value; }

        public String Kategorija { get => kategorija; set => kategorija = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
