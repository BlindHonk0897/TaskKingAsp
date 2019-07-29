using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample2.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<MiddleGenerator> MiddleGenerators { get; set; }
    }
}