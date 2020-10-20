using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string CreatedBy { get; set; }
        public System.DateTime? createdOn { get; set; }
        public string EditedBy { get; set; }
        public System.DateTime? EditedOn { get; set; }
        public string DeletedBy { get; set; }

        public string EncryptId { get; set; }
        public string DeletedOn { get; set; }
        [Phone]
        public decimal? PhoneNumber { get; set; }

    }
}
