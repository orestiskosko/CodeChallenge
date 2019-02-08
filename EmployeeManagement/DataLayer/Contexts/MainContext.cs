using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataLayer.Pocos;

namespace DataLayer.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<EmployeeChangesLog> EmployeeChangesLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Skill>().HasKey(s => s.Id);

            builder.Entity<Employee>().HasKey(e => e.Id);

            builder.Entity<EmployeeSkill>().HasKey(es => new { es.EmployeeId, es.SkillId });

            builder.Entity<EmployeeChangesLog>().HasKey(e => e.Id);


            // Database seeding
            List<Guid> skillGuids = new List<Guid>();
            List<Guid> employeeGuids = new List<Guid>();
            for (int i = 0; i < 10; i++)
            {
                skillGuids.Add(Guid.NewGuid());
                employeeGuids.Add(Guid.NewGuid());
            }

            builder.Entity<Skill>()
                .HasData(
                    new Skill { Id = skillGuids[0], Name = "C#", Description = "Programming language", CreationDate = DateTime.Now },
                    new Skill { Id = skillGuids[1], Name = "VB.NET", Description = "Programming language", CreationDate = DateTime.Now },
                    new Skill { Id = skillGuids[2], Name = "ASP.NET MVC", Description = "Framework", CreationDate = DateTime.Now },
                    new Skill { Id = skillGuids[3], Name = "ASP.NET Core MVC", Description = "Framework", CreationDate = DateTime.Now },
                    new Skill { Id = skillGuids[4], Name = "Python", Description = "Programming language", CreationDate = DateTime.Now }
                        );

            builder.Entity<Employee>()
                .HasData(
                new Employee { Id = employeeGuids[0], FirstName = "Orestis", Surname = "Koskoletos", HiringDate = DateTime.Now },
                new Employee { Id = employeeGuids[1], FirstName = "John", Surname = "Doe", HiringDate = DateTime.Now },
                new Employee { Id = employeeGuids[2], FirstName = "Jane", Surname = "Doe", HiringDate = DateTime.Now }
                );

            builder.Entity<EmployeeSkill>()
                .HasData(
                    new EmployeeSkill { EmployeeId = employeeGuids[0], SkillId = skillGuids[0] },
                    new EmployeeSkill { EmployeeId = employeeGuids[0], SkillId = skillGuids[1] },
                    new EmployeeSkill { EmployeeId = employeeGuids[0], SkillId = skillGuids[2] },
                    new EmployeeSkill { EmployeeId = employeeGuids[0], SkillId = skillGuids[3] },
                    new EmployeeSkill { EmployeeId = employeeGuids[1], SkillId = skillGuids[0] },
                    new EmployeeSkill { EmployeeId = employeeGuids[1], SkillId = skillGuids[1] },
                    new EmployeeSkill { EmployeeId = employeeGuids[2], SkillId = skillGuids[0] }
                );
        }
    }
}
