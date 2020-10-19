using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repositorys.Irepository;
using Dapper;
using Model;

namespace DAL.Repositorys
{
    public class CustomerRepository :ICustomer
    {
        readonly DynamicParameters param = new DynamicParameters();
        public Customer GetCustomer(int id)
        {
            return (GetAllCustomers().FirstOrDefault(x => x.CustomerId == id));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return ORM.Dapper.ReturnList<Customer>("SEARCHCUSTOMER");
        }

        public Customer AddCustomer(Customer Customer)
        {
            param.Add("@customerName", Customer.CustomerName);
            param.Add("@address", Customer.Address);
            param.Add("@phonenumber", Customer.PhoneNumber);
            param.Add("@STATUS", "INSERT");
            ORM.Dapper.ExceptionWithoutReturn("CRUDCUSTOMER", param);
            return Customer;
        }

        public Customer Update(Customer Customer)
        {
            var pro = GetAllCustomers().FirstOrDefault(q => q.CustomerId == Customer.CustomerId);
            if (pro is null) return pro;
            param.Add("@customerName", Customer.CustomerName);
            param.Add("@address", Customer.Address);
            param.Add("@phonenumber", Customer.PhoneNumber);
            param.Add("@STATUS", "UPDATE");
            param.Add("@customerID", Customer.CustomerId);
            ORM.Dapper.ExceptionWithoutReturn("CRUDPRODUCT", param);
            return Customer;
        }

        public Customer DeleteCustomer(int id)
        {
            var pro = GetAllCustomers().FirstOrDefault(q => q.CustomerId == id);
            if (pro is null) return pro;
            param.Add("@customerID", id);
            param.Add("@STATUS", "DELETE");
            ORM.Dapper.ExceptionWithoutReturn("CRUDPRODUCT", param);
            return pro;
        }
    }
}
