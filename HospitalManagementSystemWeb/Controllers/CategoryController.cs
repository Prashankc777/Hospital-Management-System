using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositorys.Irepository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Custom;
using Model.Product;

namespace HospitalManagementSystemWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        private readonly IDataProtector _protector;

        public CategoryController(ICategory category, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
           _category = category;
           _protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);

        }

        public IActionResult ShowAllCategories()
        {
            var model = _category.GetAllCategories().Select(e =>
            {
                e.EncryptId = _protector.Protect(e.CategoryId.ToString());
                return e;
            });
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid || !_category.IsCategoryExist(category.CategoryName)) return View();
            _category.AddCategory(category);
            return RedirectToAction(nameof(ShowAllCategories));

        }
        [HttpGet]
        public IActionResult Editcategory(string id)
        {
            var category = _category.GetCategory(Convert.ToInt32(_protector.Unprotect(id)));
            return category is null ? View() : View(category);
        }

        [HttpPost]
        public IActionResult EditProduct(Category category)
        {
            if (!ModelState.IsValid) return View();
             _category.UpdateCategory(category);
            return RedirectToAction(nameof(ShowAllCategories));
        }

        [HttpGet]
        public IActionResult DeleteProduct(string id)
        {
            return !ModelState.IsValid ? View() : View(_category.GetCategory(Convert.ToInt32(_protector.Unprotect(id))));
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            if (!ModelState.IsValid) return View();
            var emp = _category.DeleteCategory(id);
            return RedirectToAction(nameof(ShowAllCategories));
        }






    }
}
