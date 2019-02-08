using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.HistoryLogging;
using DataLayer.Pocos;
using DataLayer.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repos
{
    public class EmployeeRepo : IGenericRepo<Employee, Guid>
    {
        private readonly MainContext _ctx;
        private readonly IChangesLogger _changesLogger;

        public EmployeeRepo(
            MainContext ctx,
            IChangesLogger changesLogger)
        {
            _ctx = ctx;
            _changesLogger = changesLogger;
        }



        public void Delete(Employee obj)
        {
            _ctx.Employees.Remove(obj);
            _ctx.SaveChanges();
        }

        public void DeleteMultiple(IEnumerable<Employee> obj)
        {
            _ctx.Employees.RemoveRange(obj);
            _ctx.SaveChanges();
        }

        public IEnumerable<Employee> GetAll(bool joinAll = false)
        {
            return joinAll
                ? _ctx.Employees
                    .Include(e => e.EmployeeSkills)
                    .ThenInclude(es => es.Skill)
                    .ToList()
                : _ctx.Employees.ToList();
        }

        public Employee GetById(Guid id, bool joinAll = false)
        {
            return joinAll
                ? _ctx.Employees
                    .Include(e => e.EmployeeSkills)
                    .ThenInclude(es => es.Skill)
                    .FirstOrDefault(e => e.Id == id)
                : _ctx.Employees.Find(id);
        }

        public void Insert(Employee obj)
        {
            obj.LastSkillChangeDate = DateTime.Now;
            _ctx.Employees.Add(obj);
            _ctx.SaveChanges();
        }

        public void Update(Employee obj)
        {
            Employee trackedEmployee = GetById(obj.Id, true);
            trackedEmployee.FirstName = obj.FirstName;
            trackedEmployee.Surname = obj.Surname;
            trackedEmployee.HiringDate = obj.HiringDate;
            trackedEmployee.EmployeeSkills = obj.EmployeeSkills;
           
            // TODO This IF statement is not working as intended.
            if (_ctx.Entry(trackedEmployee).Collection(e => e.EmployeeSkills).IsModified)
            {
                trackedEmployee.LastSkillChangeDate = DateTime.Now;
            }

            // TODO Cannot find certain modified properties and log them.
            foreach (var prop in _ctx.Entry(trackedEmployee).Properties)
            {
                if (prop.IsModified)
                {
                    _changesLogger.Log(
                        $"{trackedEmployee.FirstName} {trackedEmployee.Surname} {trackedEmployee.Id.ToString()}",
                        $"Property {prop.Metadata.Name} has been changed.",
                        prop.OriginalValue.ToString(),
                        prop.CurrentValue.ToString()
                    );
                }
            }

            _ctx.SaveChanges();

            
        }
    }
}
