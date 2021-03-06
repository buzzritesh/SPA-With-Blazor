﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSPA.Server.DataAccess;
using BlazorSPA.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorSPA.Server.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        // To Fetch all employee records
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Index()
        {
            return objemployee.GetAllEmployees();
        }

        // To Create a new employee record
        [HttpPost]
        [Route("api/Employee/Create")]
        public void Create([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
                objemployee.AddEmployee(employee);
        }

        // To fetch the details of a particular employee
        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Employee Details(int id)
        {

            return objemployee.GetEmployeeData(id);
        }

        // Edit an existing employee records
        [HttpPut]
        [Route("api/Employee/Edit")]
        public void Edit([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
                objemployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public void Delete(int id)
        {
            objemployee.DeleteEmployee(id);
        }

    }
}
