using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monolitycznie
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1. Komputer losuje liczbę z podanego zakresu
            Random los = new Random();
            int wylosowana = los.Next(1, 101);
#if DEBUG
            Console.WriteLine(wylosowana); // do usunięcia w Release
#endif
            Console.WriteLine("Wylosowałem liczbę z zakresu od 1 do 100. Odgadnij ją.");

            Stopwatch czas = Stopwatch.StartNew();

            // Powtarzaj wielokrotnie, aż odgadnie
            bool odgadniete = false;
            int licznik = 0;

            do
            {
                licznik++;
                // 2. Człowiek proponuje  (odgaduje)
                Console.Write("Podaj swoją propozycję: ");
                string napis = Console.ReadLine();
                if (napis == "koniec" )
                {
                    Console.WriteLine("Szkoda, że mnie opuszczasz..");
                    return;
                }

                int propozycja = 0;
                try
                {
                    propozycja = int.Parse(napis);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podano liczby. \nSpróbuj jeszcze raz.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Przesadziłeś! Za duża liczba.");
                    continue;
                }
                catch(Exception)
                {
                    Console.WriteLine("Niezydentyfikowany wyjątek. Awaria!");
                    Environment.Exit(1);
                }

                // 3. Komputer ocenia propozycję
                if (propozycja < wylosowana)
                {
                    Console.WriteLine("Za mało.");
                }
                else if (propozycja > wylosowana)
                {
                    Console.WriteLine("Za dużo.");
                }
                else
                {
                    Console.WriteLine("Trafiłeś!");
                    //odgadniete = true; lub while( propozycja != wylosowana ) lub
                    break; // wychodzimy z pętli
                }

            }
            //while (!odgadniete);
            while (true);
            // Koniec powtarzania

            czas.Stop();

            // 4. Wypisz statystyki gry
            Console.WriteLine($"- Liczba ruchów: {licznik}");
            Console.WriteLine($"- Czas gry: {czas.Elapsed}");
        }
    }
}
