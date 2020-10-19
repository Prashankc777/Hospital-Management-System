using System;
using System.Collections.Generic;
using System.Text;
using Model.Product;

namespace DAL.Repositorys.Irepository
{

    public interface IProduct
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product Update(Product product);
        Product DeleteProduct(int id);

    }
}
