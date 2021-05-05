using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace POSL051
{
    public class Function1Exception : ApplicationException
    {
        public int A { get; set; }
        
        public int B { get; set; }

        public int Result { get; set; }


        public Function1Exception() : base() { }
        public Function1Exception(string message) : base(message) { }
        public Function1Exception(string message, Exception innerException) : base(message, innerException) { }


    }


    class Program
    {
        static void Main(string[] args)
        {

            int result;
            try
            {
                Divider2(null, 2);
                Console.WriteLine("Done");
            }
            catch (Function1Exception ex)
            {
                result = ex.Result;
                //Console.WriteLine($"Błąd aplikacji w metodzie {ex.Message}, parametry: {ex.A}, {ex.B}");
                //if (ex.InnerException != null)
                //{
                //    Console.WriteLine(ex.InnerException.Message);
                //}
            }
            catch (ApplicationException ex)
            {

                Console.WriteLine("Błąd aplikacji w metodzie " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            catch (SystemException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }



            Console.ReadLine();
        }

        static void Divider2(Nullable<int> a, int? b)
        {
            //throw new Exception((a.Value / b.Value).ToString());


            try
            {
                if (a == null || !a.HasValue)
                {
                    throw new NullReferenceException();
                }


                if (b == null)
                {
                    throw new Function1Exception("Divider null Value")
                    {
                        A = a ?? 0,
                        B = b ?? 0
                    };
                }


                int resutl = a.Value / b.Value;
            }
            catch (Exception ex)
            {

                throw new Function1Exception("Divider", ex)
                {
                    A = a ?? 0,
                    B = b ?? 0
                };
            }
        }


        static int Divider(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception ex)
            {

                throw new Function1Exception("Divider", ex)
                {
                    A = a,
                    B = b
                };
            }
        }
    }
}
