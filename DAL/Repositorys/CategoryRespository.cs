using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repositorys.Irepository;
using Dapper;
using Model;

namespace DAL.Repositorys
{
   public class CategoryRespository :ICategory
    {
        readonly DynamicParameters _param = new DynamicParameters();
        public Category GetCategory(int id)
        {
            return (GetAllCategories().FirstOrDefault(x => x.CategoryId == id));
        }

        public IEnumerable<Category> GetAllCategories()
        {
            _param.Add("@Status", "SEARCH");
            return ORM.Dapper.ReturnList<Category>("CRUDCATEGORY", param:_param);
        }

        public Category AddCategory(Category category)
        {
            _param.Add("@CategoryName", category.CategoryName);
            _param.Add("@Status", "INSERT");
            ORM.Dapper.ExceptionWithoutReturn("CRUDCATEGORY", _param);
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var pro = GetAllCategories().FirstOrDefault(q => q.CategoryId == category.CategoryId);
            if (pro is null) return pro;
            _param.Add("@customerName", category.CategoryName);
            _param.Add("@categoryId", category.CategoryId);
            ORM.Dapper.ExceptionWithoutReturn("CRUDCATEGORY", _param);
            return category;
        }

        public Category DeleteCategory(int id)
        {
            var pro = GetAllCategories().FirstOrDefault(q => q.CategoryId == id);
            if (pro is null) return pro;
            _param.Add("@categoryId", id);
            _param.Add("@Status", "DELETE");
            ORM.Dapper.ExceptionWithoutReturn("CRUDCATEGORY", _param);
            return pro;
        }

        public bool IsCategoryExist(string category)
        {
            var pro = GetAllCategories().FirstOrDefault(x => x.CategoryName == category);
            if (pro is null) return true;
            return false;
        }
    }
}
