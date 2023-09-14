using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DMAWS_T2204M_TrungKien.Models;
using DMAWS_T2204M_TrungKien.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMAWS_T2204M_TrungKien.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ProjectContext _context;

        public EmployeesController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var emps = await _context.Employees.Include(e => e.ProjectEmployees).ToListAsync();
                return Ok(emps);
            }
            var em = await _context.Employees.Include(e => e.ProjectEmployees).Where(c => c.EmployeeId == id).FirstOrDefaultAsync();

            if (em == null) { return NotFound(); }
            return Ok(em);
        }

        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(EmployeeDTO data)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(new Employee { EmployeeName = data.EmployeeName, EmployeeDOB = data.EmployeeDOB, EmployeeDepartment = data.EmployeeDepartment, ProjectEmployees = data.ProjectEmployees});
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.EmployeeId}", data);
            }
            return BadRequest();
        }

        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(Employee data)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.Employees.Find(id);
            if (a != null)
            {
                _context.Employees.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

    }
}

