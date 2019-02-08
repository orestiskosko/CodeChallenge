using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Pocos
{
    public class EmployeeChangesLog
    {
        public Guid Id { get; set; }
        public DateTime LogStamp { get; set; }
        public string Entity { get; set; }
        public string Message { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
