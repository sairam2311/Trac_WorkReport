using Microsoft.AspNetCore.Mvc;
using Trac_WorkReport.Models;
using WorkRport.DataAccess.Repository.IRepository;

namespace Trac_WorkReport.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _ProjectsRepo;

        public ProjectsController(IProjectRepository db)
        {
            _ProjectsRepo = db;
        }
        public IActionResult Index()
        {
            List<Projects> objprojects = _ProjectsRepo.GetAll().ToList();
            return View(objprojects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Projects obj)
        {
            _ProjectsRepo.Add(obj);
            _ProjectsRepo.save();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(Guid id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }
            Projects? projectsfromDb = _ProjectsRepo.Get(u => u.ProjectId == id);
            //Designation? designationfromDb1 = _db.Designations.FirstOrDefault(u=>u.DesId == id);
            //Designation? designationfromDb2 = _db.Designations.Where(u => u.DesId == id).FirstOrDefault();
            if (projectsfromDb == null)
            {
                return NotFound();
            }
            return View(projectsfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Projects obj)
        {
            if (ModelState.IsValid)
            {
                _ProjectsRepo.update(obj);
                _ProjectsRepo.save();
                return RedirectToAction("Index");

            }
            return View();
        }



        public IActionResult Delete(Guid id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }
            Projects? projectsfromDb = _ProjectsRepo.Get(u => u.ProjectId == id);
            // Designation? designationfromDb1 = _db.Designations.FirstOrDefault(u => u.DesId == id);
            // Designation? designationfromDb2 = _db.Designations.Where(u => u.DesId == id).FirstOrDefault();
            if (projectsfromDb == null)
            {
                return NotFound();
            }
            return View(projectsfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Guid id)
        {
            Projects? obj = _ProjectsRepo.Get(u => u.ProjectId == id); if (obj == null)
            {
                return NotFound();
            }
            _ProjectsRepo.Remove(obj);
            _ProjectsRepo.save();
            return RedirectToAction("Index");

            //return View();
        }
    }
}
