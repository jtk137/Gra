using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraLib
{
    public partial class ModelGry
    {
        readonly private int wylosowana; // readonly oznacza, że nie można zmienić wartości poza konstruktorem
        public int ZakresOd { get; private set; } //wartośc tylko do odczytu, zawężamy mozliwość modyfikacji z zewnątrz (private set)
        public int ZakresDo { get; private set; }
        public enum Stan { Trwa, Poddana, Odgadnieta }  //deklaracja typu
        public Stan StanGry { get; private set; }

        public List<Ruch> Historia { get; private set; }


        public ModelGry(int zakresOd = 1, int zakresDo = 100) // konstruktor, nazwa zawsze taka sama jak klasy
        {
            ZakresOd = Math.Min(zakresOd, zakresDo);
            ZakresDo = Math.Max(zakresOd, zakresDo);
            Random los = new Random();
            wylosowana = los.Next(ZakresOd, ZakresDo + 1);
            StanGry = Stan.Trwa;
            Historia = new List<Ruch>();
        }

        public enum Odp { ZaMalo = -1, Trafione = 0, ZaDuzo = 1 };  //metody

        public Odp Ocena(int propozycja)
        {
            if (propozycja < wylosowana)
            {
                //Ruch r = new Ruch(propozycja, Odp.ZaMalo);
                //Historia.Add(r);
                Historia.Add(new Ruch(propozycja, Odp.ZaMalo));
                return Odp.ZaMalo;
            }
            else if (propozycja > wylosowana)
            {
                Historia.Add(new Ruch(propozycja, Odp.ZaDuzo));
                return Odp.ZaDuzo;
            }
            else
            {
                Historia.Add(new Ruch(propozycja, Odp.Trafione));
                StanGry = Stan.Odgadnieta;
                return Odp.Trafione;
            }
        }

        public void Poddaj()
        {
            StanGry = Stan.Poddana;
        }

        public int Wylosowana
        {
            get
            {
                if (StanGry == Stan.Poddana || StanGry == Stan.Odgadnieta)
                    return wylosowana;
                else
                    throw new NotSupportedException("Nie wolno teraz Ci tej wartości udostępnić");    
            }
        }
    }
}
