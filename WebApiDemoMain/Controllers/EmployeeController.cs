using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemoMain.BasicAuth;
using WebApiDemoMain.Models;

namespace WebApiDemoMain.Controllers
{
    [BasicAuthetication]
    public class EmployeeController : ApiController
    {
        BALEmployee objBalEmp = new BALEmployee();
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            var empList = objBalEmp.EmpoyeeList;
            if (empList != null)
            {
                return Ok(empList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                var employee = objBalEmp.EmpoyeeList.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    return Ok(employee);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult AddEmployee(Employee emp)
        {
            try
            {
                if (emp != null)
                {
                    objBalEmp.EmpoyeeList.Add(emp);
                    var addedEmployee = objBalEmp.EmpoyeeList;
                    return Ok(addedEmployee);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, Employee emp)
        {
            try
            {
                var employee = objBalEmp.EmpoyeeList.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Name = emp.Name;
                    employee.City = emp.City;
                    employee.IsActive = emp.IsActive;

                    var updatedEmployee = objBalEmp.EmpoyeeList;
                    return Ok(updatedEmployee);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = objBalEmp.EmpoyeeList.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    objBalEmp.EmpoyeeList.Remove(employee);

                    var deletedEmployee = objBalEmp.EmpoyeeList;
                    return Ok(deletedEmployee);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    
    }
}
