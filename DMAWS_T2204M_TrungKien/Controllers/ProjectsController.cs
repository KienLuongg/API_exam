using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMAWS_T2204M_TrungKien.Models;
using DMAWS_T2204M_TrungKien.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMAWS_T2204M_TrungKien.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectContext _context;

        public ProjectsController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var emps = await _context.Projects.Include(e => e.ProjectEmployees).ToListAsync();
                return Ok(emps);
            }
            var em = await _context.Projects.Include(e => e.ProjectEmployees).Where(c => c.ProjectId == id).FirstOrDefaultAsync();

            if (em == null) { return NotFound(); }
            return Ok(em);
        }

        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(ProjectDTO data)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(new Project { ProjectName = data.ProjectName, ProjectStartDate = data.ProjectStartDate, ProjectEndDate = data.ProjectEndDate, ProjectEmployees = data.ProjectEmployees });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.ProjectId}", data);
            }
            return BadRequest();
        }

        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(Project data)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.Projects.Find(id);
            if (a != null)
            {
                _context.Projects.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet, Route("search_by_name")]
        async public Task<IActionResult> Get(string? projectName)
        {
            var em = await _context.Projects.FindAsync(projectName);

            if (em == null) { return NotFound(); }
            return Ok(em);
        }


    }
}

