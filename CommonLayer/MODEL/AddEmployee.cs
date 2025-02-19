using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.MODEL
{
    public class AddEmployee
    {
        
        public string Name { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
    }
}
