using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppCore.DbModels;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new  BikeStoresContext())
            {
                //var brands = db.Brands.ToList();

                //var brand = brands.FirstOrDefault();

                //brand.BrandName = "YYYYY";

                //db.Update(brand);

                //db.SaveChanges();

                db.Discounts.Add(new Discount()
                {
                    CategoryId = 1,
                    Code = "TEST",
                    DicuntValue = .5
                });

                db.SaveChanges();
            }


            Console.WriteLine("test");
            Console.ReadLine();
        }

     
    }
}
