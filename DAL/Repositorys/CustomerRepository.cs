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
        readonly DynamicParameters _param = new DynamicParameters();
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
            _param.Add("@customerName", Customer.CustomerName);
            _param.Add("@address", Customer.Address);
            _param.Add("@phonenumber", Customer.PhoneNumber);
            _param.Add("@STATUS", "INSERT");
            ORM.Dapper.ExceptionWithoutReturn("CRUDCUSTOMER", _param);
            return Customer;
        }

        public Customer Update(Customer customer)
        {
            var pro = GetAllCustomers().FirstOrDefault(q => q.CustomerId == customer.CustomerId);
            if (pro is null) return pro;
            _param.Add("@customerName", customer.CustomerName);
            _param.Add("@address", customer.Address);
            _param.Add("@phonenumber", customer.PhoneNumber);
            _param.Add("@STATUS", "UPDATE");
            _param.Add("@customerID", customer.CustomerId);
            ORM.Dapper.ExceptionWithoutReturn("CRUDCUSTOMER", _param);
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            var pro = GetAllCustomers().FirstOrDefault(q => q.CustomerId == id);
            if (pro is null) return pro;
            _param.Add("@customerID", id);
            _param.Add("@status", "DELETE");
            ORM.Dapper.ExceptionWithoutReturn("CRUDCUSTOMER", _param);
            return pro;
        }

        
    }
}
