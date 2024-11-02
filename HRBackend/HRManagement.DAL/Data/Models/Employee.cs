using HRManagement.DAL.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Data.Models
{

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public decimal Salary { get; set; }
            public string SIN { get; set; }
            public string Phone { get; set; }
            public Status IsActive { get; set; } = Status.Deactive; 
        }

    
}
