using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Pocos
{
    public class EmployeeSkill
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }


}
