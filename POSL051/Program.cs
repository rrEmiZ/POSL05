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

        static void Main(string[] args)
        {
            var foo = new Foo()
            {
                MyProperty = 10
            };


            //z użyciem refleksji
            var type = Type.GetType("POSL051.Foo"); //string powinien zawierać namespace naszej klasy

            var methods = type.GetMethods();

            MethodInfo inf = type.GetMethod("Hello");

            inf.Invoke(foo, null); // jako drugi parametr metoda Invoke przyjmuje tablicę  Object[] są to parametry metody hello.

            var propInfo = type.GetProperty("MyProperty");

            var propValue = propInfo.GetValue(foo);

            inf.Invoke(foo, null);

            Console.ReadLine();
        }



    }
}
