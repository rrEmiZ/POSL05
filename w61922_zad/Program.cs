using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Reflection;

namespace w61922_zad
{
    // zad 1,2
    class Program
    {
        static void GetMethods(object obj)
        {
            var type = obj.GetType();
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine("Metoda" + method.Name + " ,params " + string.Join(",", method.GetParameters().Select(x => x.Name)));
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
        }

        static void GetProperties(object obj)
        {
            var type = obj.GetType();
            var Properties = type.GetProperties();
            foreach (var property in Properties)
            {
                Console.WriteLine("Właściwość " + string.Join(",", property.Name));
            }
        }
        static void Main(string[] args)
        {

            GetProperties("2d");
            Console.ReadLine();
        }


    }
}
