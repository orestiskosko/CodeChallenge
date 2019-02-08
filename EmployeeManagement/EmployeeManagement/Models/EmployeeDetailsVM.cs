using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Pocos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagement.Models
{
    public class EmployeeDetailsVM
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Skillset last change")]
        public DateTime LastSkillChangeDate { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public List<Guid> SkillIds { get; set; } = new List<Guid>();

        public List<SelectListItem> NewSkillOptions { get; set; } = new List<SelectListItem>();
    }
}
