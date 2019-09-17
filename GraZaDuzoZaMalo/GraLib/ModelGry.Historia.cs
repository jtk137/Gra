using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraLib
{
    public partial class ModelGry
    {
        //klasa wewnętrzna (inner class)
        public class Ruch
        {
            public DateTime Czas { get; private set; }
            public int Propozycja { get; private set; }
            public Odp Odpowiedz { get; private set; }

            public Ruch( int propozycja, Odp odpowiedz)
            {
                Czas = DateTime.Now;
                Propozycja = propozycja;
                Odpowiedz = odpowiedz;
            }

            public override string ToString() => $"{Czas} {Propozycja} {Odpowiedz}";
        }
    }
}
