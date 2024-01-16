using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemoMain.Models
{
    public class BALEmployee
    {
        public List<Employee> EmpoyeeList = new List<Employee>
        {
            new Employee{Id=1,Name="Rushikesh",City="Mumbai",IsActive=true},
            new Employee{Id=2,Name="Rahul",City="Mulund",IsActive=true},
            new Employee{Id=3,Name="Poonam",City="Ghatkopar",IsActive=true},
            new Employee{Id=4,Name="Shruti",City="Malad",IsActive=true},
            new Employee{Id=5,Name="Rajashree",City="Sanpada",IsActive=true}
        };
    }
}