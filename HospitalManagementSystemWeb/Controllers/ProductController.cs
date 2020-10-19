using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositorys.Irepository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Model.Custom;
using Model.Product;


namespace HospitalManagementSystemWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly IDataProtector protector;

        public ProductController(IProduct product, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _product = product;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }

        public IActionResult GetAllProduct()
        {
            var model = _product.GetAllProducts().Select(e =>
            {
                e.EncryptId = protector.Protect(e.ProductId.ToString());
                return e;
            });
            return View(model);

        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid) return View();
            var emp = _product.AddProduct(product);
            return RedirectToAction(nameof(GetAllProduct));
        }

        [HttpGet] 
        public IActionResult EditProduct(string id)
        {
            if (!ModelState.IsValid) return View();

            
            var emp = _product.GetProduct(Convert.ToInt32(protector.Unprotect(id)));
            return View(emp);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid) return View();
            var emp = _product.Update(product);
            return RedirectToAction(nameof(GetAllProduct));
        }

        [HttpGet]
        public IActionResult DeleteProduct(string id)
        {
            if (!ModelState.IsValid) return View();
            var emp = _product.GetProduct(Convert.ToInt32(protector.Unprotect(id)));
            return View(emp);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            if (!ModelState.IsValid) return View();
            var emp = _product.DeleteProduct(id);
            return RedirectToAction(nameof(GetAllProduct));
        }


    }
}
