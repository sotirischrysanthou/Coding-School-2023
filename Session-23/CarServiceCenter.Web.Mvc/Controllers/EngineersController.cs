using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class EngineersController : Controller {
        // Properties
        private readonly IEntityRepo<Manager> _managerRepo;
        private readonly IEntityRepo<Engineer> _engineerRepo;

        // Constructors
        public EngineersController(IEntityRepo<Manager> managerRepo, IEntityRepo<Engineer> engineerRepo) {
            _managerRepo = managerRepo;
            _engineerRepo = engineerRepo;
        }

        // GET: EngineersController
        public ActionResult Index() {
            var dbEngineers = _engineerRepo.GetAll();
            return View(dbEngineers);
        }

        // GET: EngineersController/Details/5
        public ActionResult Details(int id) {
            Engineer? dbEngineer = _engineerRepo.GetById(id);
            if (dbEngineer is null) {
                return NotFound();
            }
            return View(dbEngineer);
        }

        // GET: EngineersController/Create
        public ActionResult Create() {
            var managers = _managerRepo.GetAll();
            var selectManagersList = managers.Select(e => new SelectListItem {
                Value = e.Id.ToString(),
                Text = e.Name
            });
            ViewBag.Managers = selectManagersList;
            EngineerCreateDto engineerCreateDto = new EngineerCreateDto() {
                StartDate = DateTime.Now,
            };
            return View(model: engineerCreateDto);
        }

        // POST: EngineersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EngineerCreateDto engineer) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Create");
            }
            Engineer dbEngineer = new Engineer(engineer.Name, engineer.Surname, engineer.SalaryPerMonth) {
                ManagerId = engineer.ManagerId,
                StartDate = engineer.StartDate,
            };
            _engineerRepo.Add(dbEngineer);
            return RedirectToAction("Index");
        }

        // GET: EngineersController/Edit/5
        public ActionResult Edit(int id) {
            Engineer? dbEngineer = _engineerRepo.GetById(id);
            if (dbEngineer is null) {
                return NotFound();
            }
            var managers = _managerRepo.GetAll();
            var selectManagersList = managers.Select(m => new SelectListItem {
                Value = m.Id.ToString(),
                Text = m.Name + " " + m.Surname
            });
            ViewBag.Managers = selectManagersList;
            EngineerEditDto engineer = new EngineerEditDto {
                Id = dbEngineer.Id,
                Name = dbEngineer.Name,
                SalaryPerMonth = dbEngineer.SalaryPerMonth,
                ManagerId = dbEngineer.ManagerId,
                StartDate = dbEngineer.StartDate,
            };
            return View(model: engineer);
        }

        // POST: EngineersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EngineerEditDto engineer) {
            if (!ModelState.IsValid) {
                return RedirectToAction(actionName: "Edit", routeValues: id);
            }
            Engineer? dbEngineer = _engineerRepo.GetById(id);
            if (dbEngineer is null) {
                return NotFound();
            }
            dbEngineer.Name = engineer.Name;
            dbEngineer.Surname = engineer.Surname;
            dbEngineer.SalaryPerMonth = engineer.SalaryPerMonth;
            dbEngineer.ManagerId = engineer.ManagerId;
            dbEngineer.StartDate = engineer.StartDate;
            _engineerRepo.Update(id, dbEngineer);
            return RedirectToAction(actionName: "Index");
        }

        // GET: EngineersController/Delete/5
        public ActionResult Delete(int id) {
            Engineer? dbEngineer = _engineerRepo.GetById(id);
            if (dbEngineer is null) {
                return NotFound();
            }
            return View(dbEngineer);
        }

        // POST: EngineersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            if (!ModelState.IsValid) {
                return RedirectToAction(actionName: "Delete", routeValues: id);
            }
            Engineer? dbEngineer = _engineerRepo.GetById(id);
            if (dbEngineer is null) {
                return NotFound();
            }
            _engineerRepo.Delete(id);
            return RedirectToAction(actionName: "Index");
        }
    }
}
