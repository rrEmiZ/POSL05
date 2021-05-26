using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Products.Dto
{
    public class ProductDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public short ModelYear { get;  set; }
        public decimal Price { get;  set; }
        public string BrandName { get;  set; }
        public int BrandId { get;  set; }
        public int CategoryId { get;  set; }
        public string CategoryName { get;  set; }
    }
}
