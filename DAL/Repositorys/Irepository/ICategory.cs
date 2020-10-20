using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Repositorys.Irepository
{
    public interface ICategory
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategories();
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        Category DeleteCategory(int id);

        bool IsCategoryExist(string category);


    }
}
