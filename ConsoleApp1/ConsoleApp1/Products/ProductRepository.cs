using ConsoleApp1.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Products
{
    public class ProductRepository
    {
        private readonly BikeStoresEntities _db;

        public ProductRepository(BikeStoresEntities db)
        {
            _db = db;
        }

        public List<ProductDto> GetProducts()
        {
            return _db.products.Select(x => new ProductDto()
            {
                Id = x.product_id,
                Name = x.product_name,
                ModelYear = x.model_year,
                Price =  x.list_price,
                BrandName = x.brand.brand_name,
                BrandId = x.brand_id,
                CategoryName = x.category.category_name,
                CategoryId = x.category_id
            }).ToList();
        }



    }
}
