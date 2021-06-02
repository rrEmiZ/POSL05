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

        static List<ProductDto> GetProducts(DateTime date)
        {
            using (var db = new BikeStoresContext())
            {
                var disconts = db.Discounts.Where(x => x.DateFrom >= date && x.DateTo <= date).ToList();

                var products = db.Products.ToList();


                return products.Select(p =>
                {
                    var dto = new ProductDto()
                    {
                        Name = p.ProductName
                    };

                    if (disconts.Any(d => d.ProductId == p.ProductId || d.BrandId == p.BrandId || d.CategoryId == p.CategoryId))
                    {
                        if (disconts.Any(d => d.ProductId == p.ProductId))
                        {
                            var discount = disconts.FirstOrDefault(d => d.ProductId == p.ProductId);

                            dto.Price = p.ListPrice - (p.ListPrice * discount.DicountProcent);
                        }

                        //Brand ..


                        //Category..
                    }


                    return dto;
                }).ToList();


            }
        }
    }
}
