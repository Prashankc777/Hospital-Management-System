using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ViewModel
{
   public class ProductViewModel
    {

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public Product.Product Product { get; set; }
    }
}
