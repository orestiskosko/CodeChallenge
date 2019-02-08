using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Pocos;
using DataLayer.Repos.Interfaces;
using EmployeeManagement.Models;
using DataLayer.HistoryLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IGenericRepo<Employee, Guid> _employeeRepo;
        private readonly IGenericRepo<Skill, Guid> _skillRepo;

        public EmployeesController(
            IGenericRepo<Employee, Guid> employeeRepo,
            IGenericRepo<Skill, Guid> skillRepo
        )
        {
            _employeeRepo = employeeRepo;
            _skillRepo = skillRepo;
        }



        [HttpGet]
        public IActionResult Index(string orderingOption, string searchString, NotificationVM notificationVM)
        {
            List<Employee> employees = _employeeRepo.GetAll().ToList();

            switch (orderingOption)
            {
                case "surnameAsc":
                    employees = employees.OrderBy(e => e.Surname.ToUpper()).ToList();
                    break;

                case "surnameDesc":
                    employees = employees.OrderByDescending(e => e.Surname.ToUpper()).ToList();
                    break;

                case "hiringDateAsc":
                    employees = employees.OrderBy(e => e.HiringDate).ToList();
                    break;

                case "hiringDateDesc":
                    employees = employees.OrderByDescending(e => e.HiringDate).ToList();
                    break;

                default:
                    break;
            }

            ViewBag.OrderingOption = orderingOption;
            ViewBag.SearchString = searchString;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                return View(
                    employees.Where(e => string.Concat(e.FirstName.ToLower(), " ", e.Surname.ToLower()).Contains(searchString.Trim().ToLower()))
                    );
            }

            ViewBag.NotificationModel = notificationVM;
            return View(employees);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id != null)
            {
                Employee emp = _employeeRepo.GetById(id, true);

                EmployeeDetailsVM vm = new EmployeeDetailsVM
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    Surname = emp.Surname,
                    HiringDate = emp.HiringDate,
                    LastSkillChangeDate = emp.LastSkillChangeDate,
                    SkillIds = emp.EmployeeSkills.Select(es => es.SkillId).ToList(),
                    Skills = emp.EmployeeSkills.Select(e => e.Skill).ToList(),
                    NewSkillOptions = _skillRepo.GetAll(true)
                        .Select(s => new SelectListItem
                        {
                            Value = s.Id.ToString(),
                            Text = s.Name
                        }).ToList()
                };
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmployeeDetailsVM vm)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    Id = vm.Id,
                    FirstName = vm.FirstName,
                    Surname = vm.Surname,
                    HiringDate = vm.HiringDate,
                    EmployeeSkills = vm.SkillIds.Select(s => new EmployeeSkill { EmployeeId = vm.Id, SkillId = s }).ToList()
                };
                _employeeRepo.Update(employee);

                return RedirectToAction(nameof(Index),
                    new NotificationVM($"Employee {string.Concat(employee.FirstName, " ", employee.Surname)}  was updated successfully.",
                        NotificationLevel.Warning)
                    );
            }

            return RedirectToAction(nameof(Details), new { vm.Id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            EmployeeDetailsVM vm = new EmployeeDetailsVM
            {
                NewSkillOptions = _skillRepo.GetAll(true)
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDetailsVM vm)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    FirstName = vm.FirstName,
                    Surname = vm.Surname,
                    HiringDate = vm.HiringDate,
                    EmployeeSkills = vm.SkillIds.Select(s => new EmployeeSkill { EmployeeId = vm.Id, SkillId = s }).ToList()
                };
                _employeeRepo.Insert(employee);

                return RedirectToAction(nameof(Index),
                    new NotificationVM($"Employee {string.Concat(employee.FirstName, " ", employee.Surname)} was created successfully.",
                        NotificationLevel.Info)
                    );
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee)
        {
            _employeeRepo.Delete(employee);
            return RedirectToAction(nameof(Index),
                new NotificationVM($"Employee {string.Concat(employee.FirstName, " ", employee.Surname)} was deleted successfully.",
                    NotificationLevel.Critical)
                );
        }

        [HttpPost]
        public IActionResult DeleteMultiple([FromBody] Employee[] employees)
        {
            _employeeRepo.DeleteMultiple(employees);
            return RedirectToAction(nameof(Index),
                new NotificationVM($"Selected employees were deleted successfully.",
                    NotificationLevel.Critical)
            );
        }
    }
}