using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WseiLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ulamek a = new Ulamek(2, 4);
            Ulamek b = new Ulamek(5, 8);
            Ulamek c = new Ulamek(1, 3);
            Ulamek e = new Ulamek(7, 5);

            Ulamek f = a.Uprosc();
            Console.WriteLine("uproszczony ułamek to " + f.ToString());

            Ulamek d = a + c;

            Console.WriteLine("wyświetl ułamek d => " + d.ToString());

            if (c == e)
                Console.WriteLine("tak to jest c = e");
            else
                Console.WriteLine("nie to nie jest c = e");

            Console.WriteLine((a + b).ToString());
            Console.WriteLine((c / b).ToString());

            Ulamek[] tablicaUlamkow = Ulamek.LosoweUlamki(10);
            Ulamek.PrintArray(tablicaUlamkow);
            Array.Sort(tablicaUlamkow);
            Ulamek.PrintArray(tablicaUlamkow);

            System.Threading.Thread.Sleep(20000);
        }


        
    }
}
