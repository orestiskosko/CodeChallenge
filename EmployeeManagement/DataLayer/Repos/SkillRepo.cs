using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Pocos;
using DataLayer.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repos
{
    public class SkillRepo : IGenericRepo<Skill, Guid>
    {
        private readonly MainContext _ctx;

        public SkillRepo(MainContext ctx) => _ctx = ctx;


        public IEnumerable<Skill> GetAll(bool joinAll = false)
        {
            return joinAll ?
               _ctx.Skills
                .Include(s => s.EmployeeSkills)
                .ThenInclude(es => es.Employee)
                .ToList()
               : _ctx.Skills.ToList();
        }


        public Skill GetById(Guid id, bool joinAll = false)
        {
            return joinAll ?
                _ctx.Skills
                    .Include(s => s.EmployeeSkills)
                    .ThenInclude(es => es.Employee)
                    .FirstOrDefault()
                : _ctx.Skills.Find(id);
        }


        public void Insert(Skill obj)
        {
            obj.CreationDate = DateTime.Now;
            _ctx.Skills.Add(obj);
            _ctx.SaveChanges();
        }


        public void Update(Skill obj)
        {
            Skill trackedSkill = GetById(obj.Id);
            trackedSkill.Name = obj.Name;
            trackedSkill.Description = obj.Description;
            _ctx.SaveChanges();
        }


        public void Delete(Skill obj)
        {
            _ctx.Skills.Remove(obj);
            _ctx.SaveChanges();
        }


        public IEnumerable<Skill> GetSkillWithEmployees(Guid id)
        {
            return _ctx.Skills
                .Where(s => s.Id == id)
                .Include(s => s.EmployeeSkills)
                .ThenInclude(es => es.Employee);
        }

        public void DeleteMultiple(IEnumerable<Skill> obj)
        {
            _ctx.Skills.RemoveRange(obj);
            _ctx.SaveChanges();
        }
    }
}
