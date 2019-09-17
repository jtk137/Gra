using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraLib;

namespace ConsoleAppGra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj od: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Podaj do: ");
            int y = int.Parse(Console.ReadLine());

            ModelGry gra = new ModelGry(x, y);
            int propozycja;
            Console.Write("Podaj propozycję: ");
            propozycja = int.Parse(Console.ReadLine());
            Console.WriteLine( gra.Ocena(propozycja));

            Console.Write("Podaj propozycję: ");
            propozycja = int.Parse(Console.ReadLine());
            Console.WriteLine(gra.Ocena(propozycja));

            Console.Write("Podaj propozycję: ");
            propozycja = int.Parse(Console.ReadLine());
            Console.WriteLine(gra.Ocena(propozycja));

            //Console.WriteLine( gra.Historia );
            int licznik = 1;
            foreach (var r in gra.Historia )
            {
                //Console.WriteLine(r);
                Console.WriteLine( $"{licznik}.  {r.Propozycja} --> {r.Odpowiedz} ({r.Czas})");
                licznik++;
            }
            gra.Poddaj();
            if( gra.StanGry != ModelGry.Stan.Trwa )
            Console.WriteLine($"Wylosowana = {gra.Wylosowana}");
        }
    }
}
