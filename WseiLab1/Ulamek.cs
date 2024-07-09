using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WseiLab1
{
    internal class Ulamek : IComparable<Ulamek>
    {
        int licznik;
        int mianownik;

        public Ulamek Uprosc()
        {
            int gcd = ZnajdzGCD(licznik, mianownik);
            if (gcd == 1)
                return this;
            else
            {
                licznik /= gcd;
                mianownik /= gcd;
                return new Ulamek(licznik, mianownik);
            }
        } 

        public Ulamek(int inLicznik, int inMianownik)
        {
            if (inMianownik == 0)
                throw new ArgumentException("Mianownik nie może wynosić 0!");
            licznik = inLicznik;
            mianownik = inMianownik;
        }


        public static Ulamek[] LosoweUlamki(int ilosc)
        {
            Ulamek[] tablicaUlamkow = new Ulamek[ilosc];
            Random rnd = new Random(); 

            for (int i = 0; i < ilosc; i++)
            {
                tablicaUlamkow[i] = new Ulamek(rnd.Next(10) + 1, rnd.Next(10) + 1); 
            }
            return tablicaUlamkow;
        }

        public static void PrintArray(Ulamek[] array)
        {
            foreach (var ulamek in array)
            {
                Console.Write(ulamek + " ");
            }
            Console.WriteLine(); 
        }
        public override string ToString()
        {
            return licznik.ToString() + "/" + mianownik.ToString();
        }

        public int CompareTo(Ulamek other)
        {
            double thisValue = (double)licznik/mianownik;
            double otherValue = (double)other.licznik/other.mianownik;

            return thisValue.CompareTo(otherValue);
        }

        public static Ulamek operator *(Ulamek valueA, Ulamek valueB)
        {
            Ulamek wynik = new Ulamek(valueA.licznik * valueB.licznik, valueA.mianownik * valueB.mianownik);
            return wynik;
        }

        public static Ulamek operator /(Ulamek valueA, Ulamek valueB)
        {
            Ulamek wynik = new Ulamek(valueA.licznik * valueB.mianownik, valueA.mianownik * valueB.licznik);
            return wynik;
        }

        public static Ulamek operator +(Ulamek valueA, Ulamek valueB)
        {
            Ulamek wynik = new Ulamek(1, 1);
            wynik.mianownik = ZnajdzLCM(valueA.mianownik, valueB.mianownik);
            wynik.licznik = ((wynik.mianownik / valueA.mianownik) * valueA.licznik) + ((wynik.mianownik / valueB.mianownik) * valueB.licznik);
            return wynik;
        }

        public static Ulamek operator -(Ulamek valueA, Ulamek valueB)
        {
            Ulamek wynik = new Ulamek(1, 1);
            wynik.mianownik = ZnajdzLCM(valueA.mianownik, valueB.mianownik);
            wynik.licznik = ((wynik.mianownik / valueA.mianownik) * valueA.licznik) - ((wynik.mianownik / valueB.mianownik) * valueB.licznik);
            return wynik;
        }

        public static bool operator !=(Ulamek valueA, Ulamek valueB)
        {
            if (valueA.ToString() != valueB.ToString())
                return true;
            else
                return false;
        }
        public static bool operator ==(Ulamek valueA, Ulamek valueB)
        {
            if (valueA.ToString() == valueB.ToString())
                return true;
            else
                return false;
        }
        static int ZnajdzGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        static int ZnajdzLCM(int a, int b)
        {
            return (a * b) / ZnajdzGCD(a, b);
        }
    }
}
