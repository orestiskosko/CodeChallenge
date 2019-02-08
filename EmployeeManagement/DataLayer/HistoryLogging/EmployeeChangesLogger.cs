using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Contexts;
using DataLayer.Pocos;
using DataLayer.Repos.Interfaces;

namespace DataLayer.HistoryLogging
{
    public class EmployeeChangesLogger : IChangesLogger
    {
        private readonly IGenericRepo<EmployeeChangesLog, Guid> _changesLogRepo;

        public EmployeeChangesLogger(IGenericRepo<EmployeeChangesLog, Guid> changesLogRepo)
        {
            _changesLogRepo = changesLogRepo;
        }

        public void Log(string entityChanged, string message, string oldValue, string newValue)
        {
            EmployeeChangesLog log = new EmployeeChangesLog
            {
                Entity = entityChanged,
                Message = message,
                LogStamp = DateTime.Now,
                OldValue = oldValue,
                NewValue = newValue
            };
            _changesLogRepo.Insert(log);
        }
    }
}
