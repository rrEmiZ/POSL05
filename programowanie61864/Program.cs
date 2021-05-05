using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime;

namespace pesele61864
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("pesels.txt"))
            {
                int kobiety = 0;
                var line = sr.ReadLine();
                while (line != null)
                {
                    if (line[9] % 2 == 0)
                    {
                        kobiety++;
                    }
                    line = sr.ReadLine();
                }
                Console.WriteLine("Liczba żenskich peseli wynosi: " + kobiety);

            }
        }
    }
}


// void zapisz (string numer)
//{
//    using (var sw = new StreamWriter("E:\\sample3.txt"))
//    {
//          sw.WriteLine(numer);
//    }
//}
//zapisz("61864");


//void wczytaj(string pliki)
//{
//    using (var sr = new StreamReader("E://" + pliki + ".txt"))
//    {
//        var line = sr.ReadLine();
//        while(line != null)
//        {
//            Console.WriteLine(line);
//            line = sr.ReadLine();
//        }
//    }
//}
//wczytaj("PLIK");

