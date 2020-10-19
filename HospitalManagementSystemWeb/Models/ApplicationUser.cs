using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystemWeb.Models
{
    public class ApplicationUser :IdentityUser
    {
        public int Age { get; set; }
        public double PhoneNumber { get; set; }

        public string Address { get; set; }

        public int GenderId { get; set; }

        public string  Occupation { get; set; }




    }
}
