using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
     public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Name is blank"), Display(Name = "Customer Name")]
        [MaxLength(256, ErrorMessage = "Your name is too long, the maximum is 256 character.")]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public string EncryptId { get; set; }
       
     
        public decimal? PhoneNumber { get; set; }

    }
}
