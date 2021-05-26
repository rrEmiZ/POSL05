
using ConsoleApp1.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BikeStoresEntities();
            var repo = new ProductRepository(db);

            var products = repo.GetProducts();

            //READ
            //  var result = db.customers.Where(x => x.customer_id % 2 == 0).ToList();

            //CREATE
            //var newBrand = new brand()
            //{
            //    brand_name = "test"
            //};
            //db.brands.Add(newBrand);

            //UPDATE
            //var brand = db.brands.Where(x => x.brand_name == "test").FirstOrDefault();

            //brand.brand_name = "TTTTTEEEESSSSTTT";

            //DELETE
            //var brand = db.brands.Where(x => x.brand_id == 10).FirstOrDefault();

            //db.brands.Remove(brand);

            //db.SaveChanges();




        }
    }
}
