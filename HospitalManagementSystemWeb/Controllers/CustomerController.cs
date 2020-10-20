using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositorys.Irepository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Custom;

namespace HospitalManagementSystemWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        private readonly IDataProtector _protector;

        public CustomerController(ICustomer customer, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings )
        {
            _customer = customer;
            _protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var model = _customer.GetAllCustomers().Select(e =>
            {
                e.EncryptId = _protector.Protect(e.CustomerId.ToString());
                return e;

            });

            return View(model);
        }

        [HttpGet]
        public IActionResult CreteCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreteCustomer(Customer customer)
        {
            if (!ModelState.IsValid) return View();
            var addCustomer = _customer.AddCustomer(customer);
            return RedirectToAction(nameof(GetAllCustomer));

        }

        [HttpGet]
        public IActionResult EditCustomer(string id)
        {
            if (!ModelState.IsValid) return View();

            var GetOne = _customer.GetCustomer(int.Parse(_protector.Unprotect(id)));
            return View(GetOne);

        }

        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            if (!ModelState.IsValid) return View();
            var GetOne = _customer.Update(customer);
            return RedirectToAction(nameof(GetAllCustomer));

        }

        [HttpGet]
        public IActionResult DeleteCustomer(string id)
        {
            if (!ModelState.IsValid) return View();
            var GetOne = _customer.GetCustomer(int.Parse(_protector.Unprotect(id)));
            return View(GetOne);

        }

        [HttpPost]
        public IActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid) return View();
            var GetOne = _customer.DeleteCustomer(id);
            return RedirectToAction(nameof(GetAllCustomer));

        }




    }
}
