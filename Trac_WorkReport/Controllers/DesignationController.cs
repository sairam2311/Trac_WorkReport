using Microsoft.AspNetCore.Mvc;

using Trac_WorkReport.Models;
using WorkReport.DataAccess.Data;
using WorkRport.DataAccess.Repository.IRepository;

namespace Trac_WorkReport.Controllers
{
    public class DesignationController : Controller
    {
        private readonly  IDesignationRepository _designationRepo;
        public DesignationController(IDesignationRepository db)
        {
            _designationRepo = db;
        }

        public IActionResult Index()
        {
          List<Designation> objdesignation = _designationRepo.GetAll().ToList();
            return View(objdesignation);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Designation obj)
        {
            _designationRepo.Add(obj);
            _designationRepo.save();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            Designation? designationfromDb = _designationRepo.Get(u=>u.DesId==id);
            //Designation? designationfromDb1 = _db.Designations.FirstOrDefault(u=>u.DesId == id);
            //Designation? designationfromDb2 = _db.Designations.Where(u => u.DesId == id).FirstOrDefault();
            if (designationfromDb == null)
            {
                return NotFound();
            }
            return View(designationfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Designation obj)
        {
            if(ModelState.IsValid)
            {
                _designationRepo.update(obj);
                _designationRepo.save();
                return RedirectToAction("Index");

            }
            return View();
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Designation? designationfromDb = _designationRepo.Get(u=>u.DesId==id);
           // Designation? designationfromDb1 = _db.Designations.FirstOrDefault(u => u.DesId == id);
           // Designation? designationfromDb2 = _db.Designations.Where(u => u.DesId == id).FirstOrDefault();
            if (designationfromDb == null)
            {
                return NotFound();
            }
            return View(designationfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Designation? obj = _designationRepo.Get(u => u.DesId == id); if (obj == null)
            {
                return NotFound();
            }
            _designationRepo.Remove(obj);
            _designationRepo.save();
            return RedirectToAction("Index");
           
            //return View();
        }
    }
}
