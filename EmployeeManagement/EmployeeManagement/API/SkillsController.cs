using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Contexts;
using DataLayer.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly MainContext _ctx;
        public SkillsController(MainContext ctx)
        {
            _ctx = ctx;
        }


        // GET: Skills
        [HttpGet]
        public ActionResult<IEnumerable<Skill>> GetSkills()
        {
            var skills = _ctx.Skills;
            if (skills == null)
            {
                return NotFound();
            }

            return _ctx.Skills;
        }

        // GET: api/Skills/guid
        [HttpGet("{guid}")]
        public ActionResult<Skill> GetSkill(string guid)
        {
            var skill = _ctx.Skills.Find(Guid.Parse(guid));
            if (skill == null)
            {
                return NotFound();
            }
            return skill;
        }

        // POST: api/Skills
        [HttpPost]
        public ActionResult InsertSkill(Skill skill)
        {
            _ctx.Skills.Add(skill);
            _ctx.SaveChanges();

            return CreatedAtAction(nameof(GetSkill), new { skill.Id }, skill);
        }

        // PUT: api/Skills/guid
        [HttpPut]
        public ActionResult PutSkill(string id, Skill skill)
        {
            if(skill.Id != Guid.Parse(id))
            {
                return BadRequest();
            }

            var trackedSkill = _ctx.Skills.Find(id);
            trackedSkill.Name = skill.Name;
            trackedSkill.Description = skill.Description;
            _ctx.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Skills/guid
        [HttpDelete("{guid}")]
        public ActionResult DeleteSkill(Guid guid)
        {
            var skill = _ctx.Skills.Find(guid);

            if(skill == null)
            {
                return NotFound();
            }

            _ctx.Skills.Remove(skill);
            _ctx.SaveChanges();

            return NoContent();
        }
    }
}