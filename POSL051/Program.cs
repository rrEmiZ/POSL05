using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Reflection;

namespace POSL051
{
    public class Foo
    {
        public int MyProperty { get; set; }

        public void Hello()
        {
            Console.WriteLine("Hello from FOO!" + MyProperty);
        }
    }
   
    class Program
    {

        static void GetMethods(object obj)
        {
            var type = obj.GetType();
            Console.WriteLine("Typ: " + type.Name);

           var methods = type.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine("Metoda: " + method.Name + ", params: " +  string.Join(", ",method.GetParameters().Select(x=> x.Name)));
            }

        }

        static void Main(string[] args)
        {

            GetMethods(2d);

            Console.ReadLine();
        }



    }
}
