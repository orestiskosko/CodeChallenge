using DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.DataExport
{
    public interface IDataExport
    {
        void ExportSkillsToExcel(Skill[] skills);

    }
}
