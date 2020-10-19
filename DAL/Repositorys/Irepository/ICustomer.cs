using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Product;

namespace DAL.Repositorys.Irepository
{
    public  interface ICustomer
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer AddCustomer(Customer Customer);
        Customer Update(Customer Customer);
        Customer DeleteCustomer(int id);
    }
}
