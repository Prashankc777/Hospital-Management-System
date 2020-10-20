using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Product
{
   public class Product
   {
        [Required, Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public string Company { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        
        [NotMapped]
        public string EncryptId { get; set; }

    }
}
