using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Pocos;
using DataLayer.Repos.Interfaces;

namespace DataLayer.Repos
{
    public class EmployeeChangesLogRepo : IGenericRepo<EmployeeChangesLog, Guid>
    {
        private readonly MainContext _ctx;

        public EmployeeChangesLogRepo(
            MainContext ctx)
        {
            _ctx = ctx;
        }

        public void Delete(EmployeeChangesLog obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteMultiple(IEnumerable<EmployeeChangesLog> obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeChangesLog> GetAll(bool joinAll = false)
        {
            throw new NotImplementedException();
        }

        public EmployeeChangesLog GetById(Guid id, bool joinAll = false)
        {
            throw new NotImplementedException();
        }

        public void Insert(EmployeeChangesLog obj)
        {
            _ctx.EmployeeChangesLogs.Add(obj);
            _ctx.SaveChanges();
        }

        public void Update(EmployeeChangesLog obj)
        {
            throw new NotImplementedException();
        }
    }
}
