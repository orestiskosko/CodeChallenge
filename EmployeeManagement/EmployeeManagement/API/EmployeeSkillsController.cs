using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Pocos;

namespace EmployeeManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly MainContext _context;

        public EmployeeSkillsController(MainContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSkills
        [HttpGet]
        public IEnumerable<object> GetEmployeeSkills()
        {
            return _context.EmployeeSkills
                .Include(es => es.Employee)
                .Include(es => es.Skill)
                .Select(es => new
                {
                    es.EmployeeId,
                    EmployeeDetails = new
                    {
                        es.Employee.FirstName,
                        es.Employee.Surname,
                        es.Employee.HiringDate
                    },
                    es.SkillId,
                    skillDetails = new
                    {
                        es.Skill.Name,
                        es.Skill.Description
                    }
                });
        }

        // GET: api/EmployeeSkills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeSkill([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeSkill = await _context.EmployeeSkills
                .Where(es => es.EmployeeId == id)
                .Include(es => es.Employee)
                .Include(es => es.Skill)
                .ToListAsync();

            List<Skill> skills = employeeSkill.Select(es => es.Skill).ToList();
            Employee employee = employeeSkill.Select(es => es.Employee).First();

            if (employeeSkill == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                EmployeeId = id,
                EmployeeDetails = new { employee.FirstName, employee.Surname, employee.HiringDate },
                Skills = skills.Select(s => new { s.Id, s.Name, s.Description })
            });
        }

        // PUT: api/EmployeeSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSkill([FromRoute] Guid id, [FromBody] EmployeeSkill employeeSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeSkill.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSkillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeSkills
        [HttpPost]
        public async Task<IActionResult> PostEmployeeSkill([FromBody] EmployeeSkill employeeSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeSkills.Add(employeeSkill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeSkillExists(employeeSkill.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeSkill", new { id = employeeSkill.EmployeeId }, employeeSkill);
        }

        // DELETE: api/EmployeeSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeSkill([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeSkill = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null)
            {
                return NotFound();
            }

            _context.EmployeeSkills.Remove(employeeSkill);
            await _context.SaveChangesAsync();

            return Ok(employeeSkill);
        }

        private bool EmployeeSkillExists(Guid id)
        {
            return _context.EmployeeSkills.Any(e => e.EmployeeId == id);
        }
    }
}