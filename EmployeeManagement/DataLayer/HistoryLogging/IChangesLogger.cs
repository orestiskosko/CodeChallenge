using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.HistoryLogging
{
    public interface IChangesLogger
    {
        void Log(string entityChanged, string message, string oldValue, string newValue);
    }
}
