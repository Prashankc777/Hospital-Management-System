using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Account.ViewModel
{
   public  class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter the Email Address"), Display(Name = "User Name")]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required , DataType(dataType:DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(dataType: DataType.Password)]
        [Compare("Password", ErrorMessage = "PASSWORD AND CONFIRM PASSWORD DO NOT MATCH"), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Enter the Age") , Range(1,100, ErrorMessage = "Age must be Between 1 and 100")]
        public int Age { get; set; }
        public string Address { get; set; }

        public int GenderId { get; set; }

        public string Occupation { get; set; }
       

    }
}
