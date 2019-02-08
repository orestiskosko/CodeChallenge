using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Pocos
{
    public class Skill
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Created at")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
