using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Pocos
{
    public class Employee
    {
        public Guid Id { get;set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

        [Display(Name = "Last Skill Change")]
        [DataType(DataType.Date)]
        public DateTime LastSkillChangeDate { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
