using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required, Display(Name = "Category Name"),MaxLength(256, ErrorMessage = "Your name is too long, the maximum is 256 character.")]
        public string CategoryName { get; set; }

        [NotMapped]
        public string EncryptId { get; set; }
    }
}
