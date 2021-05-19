using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime;


namespace zad3_w61922
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("pesels.txt"))
            {
                int LicznikK = 0;

                var line = sr.ReadLine();

                while (line != null)
                {
                    if (line[9] % 2 == 0)
                    {
                        LicznikK++;
                    }
                    line = sr.ReadLine();
                }
                Console.WriteLine("Jest " + LicznikK + " zenski peseli.");

            }
        }
    }
}
