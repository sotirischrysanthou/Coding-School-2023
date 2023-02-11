using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class ManagersController : Controller {
        // Properties
        private readonly IEntityRepo<Manager> _managerRepo;

        // Constructors
        public ManagersController(IEntityRepo<Manager> managerRepo) {
            _managerRepo = managerRepo;
        }

        // GET: ManagersController
        public ActionResult Index() {
            var managers = _managerRepo.GetAll();
            return View(model: managers);
        }

        // GET: ManagersController/Details/5
        public ActionResult Details(int id) {
            Manager? manager = _managerRepo.GetById(id);
            if(manager is null) {
                return NotFound();
            }
            return View(manager);
        }

        // GET: ManagersController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: ManagersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManagerCreateDto manager) {
            if (!ModelState.IsValid) {
                return View();
            }
            Manager dbManager = new Manager(manager.Name, manager.Surname, manager.SalaryPerMonth);
            _managerRepo.Add(dbManager);
            return RedirectToAction("Index");
        }

        // GET: ManagersController/Edit/5
        public ActionResult Edit(int id) {
            Manager? dbManager = _managerRepo.GetById(id);
            if (dbManager is null) {
                return NotFound();
            }
            ManagerEditDto manager= new ManagerEditDto { 
                Id = dbManager.Id,
                Name= dbManager.Name,
                Surname= dbManager.Surname,
                SalaryPerMonth= dbManager.SalaryPerMonth
            };
            return View(model: manager);
        }

        // POST: ManagersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ManagerEditDto manager) {
            if (!ModelState.IsValid) {
                return View();
            }
            Manager? dbManager = _managerRepo.GetById(id);
            if(dbManager is null) {
                return NotFound();
            }
            dbManager.Name = manager.Name;
            dbManager.Surname = manager.Surname;
            dbManager.SalaryPerMonth = manager.SalaryPerMonth;
            _managerRepo.Update(id, dbManager);
            return RedirectToAction("Index");
        }

        // GET: ManagersController/Delete/5
        public ActionResult Delete(int id) {
            Manager? manager= _managerRepo.GetById(id);
            if (manager is null) {
                return NotFound();
            }
            return View(model: manager);
        }

        // POST: ManagersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            if (!ModelState.IsValid) {
                return View();
            }
            Manager? dbManager = _managerRepo.GetById(id);
            if (dbManager is null) {
                return NotFound();
            }
            _managerRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
