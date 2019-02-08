using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Pocos;
using DataLayer.Repos;
using DataLayer.Repos.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Services.DataExport;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class SkillsController : Controller
    {
        private readonly IGenericRepo<Skill, Guid> _skillRepo;

        public SkillsController(IGenericRepo<Skill, Guid> skillRepo) => _skillRepo = skillRepo;

        [HttpGet]
        public IActionResult Index(NotificationVM notificationVM)
        {
            ViewBag.NotificationModel = notificationVM;
            return View(_skillRepo.GetAll());
        }


        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id != null)
            {
                return View(_skillRepo.GetById(id));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillRepo.Update(skill);
                return RedirectToAction(nameof(Index),
                    new NotificationVM($"Skill {skill.Name}  was updated successfully.",
                        NotificationLevel.Warning)
                );
            }

            return View(skill);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                skill.CreationDate = DateTime.Now;
                _skillRepo.Insert(skill);
                return RedirectToAction(nameof(Index),
                    new NotificationVM($"Skill {skill.Name}  was created successfully.",
                        NotificationLevel.Info)
                );
            }

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Skill skill)
        {
            _skillRepo.Delete(skill);
            return RedirectToAction(nameof(Index),
                new NotificationVM($"Skill {skill.Name}  was deleted successfully.",
                    NotificationLevel.Critical)
            );
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Export()
        {
            IDataExport exporter = new DataExport();
            exporter.ExportSkillsToExcel(_skillRepo.GetAll().ToArray());

            string fileName = @"Skills.xlsx";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }

            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Skills.xlsx");
        }
    }
}