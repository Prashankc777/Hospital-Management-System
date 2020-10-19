using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repositorys.Irepository;
using Dapper;
using Model.Product;

namespace DAL.Repositorys
{
   public  class ProductRepository : IProduct
    {
        readonly DynamicParameters param = new DynamicParameters();

        public Product GetProduct(int id)
        {
            return (GetAllProducts().FirstOrDefault(x => x.ProductId == id));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return ORM.Dapper.ReturnList<Product>("SEARCHPRODUCT");
           
        }

        public Product AddProduct(Product product)
        {
           param.Add("@name", product.Name);
           param.Add("@price", product.Price);
           param.Add("@company", product.Company);
           param.Add("@status", "INSERT");
           ORM.Dapper.ExceptionWithoutReturn("CRUDPRODUCT",param);
           return product;
        }

        public Product Update(Product product)
        {
            var pro = GetAllProducts().FirstOrDefault(q => q.ProductId == product.ProductId);
            if (pro is null) return pro;
            param.Add("@name", product.Name);
            param.Add("@price", product.Price);
            param.Add("@status", "UPDATE");
            param.Add("@productId", product.ProductId);
            param.Add("@company", product.Company);
            ORM.Dapper.ExceptionWithoutReturn("CRUDPRODUCT", param);
            return product;
        }

        public Product DeleteProduct(int id)
        {
            var pro = GetAllProducts().FirstOrDefault(q => q.ProductId == id);
            if (pro is null) return pro;
            param.Add("@productId", id);
            param.Add("@status", "DELETE");
            ORM.Dapper.ExceptionWithoutReturn("CRUDPRODUCT", param);
            return pro;

        }
    }
}
