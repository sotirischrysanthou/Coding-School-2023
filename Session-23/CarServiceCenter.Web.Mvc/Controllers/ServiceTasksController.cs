using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class ServiceTasksController : Controller {
        // Properties
        private readonly IEntityRepo<ServiceTask> _serviceTaskRepo;

        // Constructors
        public ServiceTasksController(IEntityRepo<ServiceTask> serviceTaskRepo) {
            _serviceTaskRepo = serviceTaskRepo;
        }

        // GET: ServiceTasksController
        public ActionResult Index() {
            var serviceTasks = _serviceTaskRepo.GetAll();
            return View(model: serviceTasks);
        }

        // GET: ServiceTasksController/Details/5
        public ActionResult Details(int id) {
            ServiceTask? serviceTask = _serviceTaskRepo.GetById(id);
            if (serviceTask is null) {
                return NotFound();
            }
            return View(model: serviceTask);
        }

        // GET: ServiceTasksController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: ServiceTasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceTaskCreateDto serviceTask) {
            if (!ModelState.IsValid) {
                return View();
            }
            ServiceTask dbServiceTask = new ServiceTask(serviceTask.Code, serviceTask.Description, serviceTask.Hours);
            _serviceTaskRepo.Add(dbServiceTask);
            return RedirectToAction("Index");
        }

        // GET: ServiceTasksController/Edit/5
        public ActionResult Edit(int id) {
            ServiceTask? dbServiceTask = _serviceTaskRepo.GetById(id);
            if(dbServiceTask is null) {
                return NotFound();
            }
            ServiceTaskEditDto serviceTask = new ServiceTaskEditDto {
                Id = dbServiceTask.Id,
                Code = dbServiceTask.Code,
                Description = dbServiceTask.Description,
                Hours = dbServiceTask.Hours
            };
            return View(model: serviceTask);
        }

        // POST: ServiceTasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceTaskEditDto serviceTask) {
            if (!ModelState.IsValid) {
                return View(model: serviceTask);
            }
            ServiceTask? dbServiceTask = _serviceTaskRepo.GetById(id);
            if(dbServiceTask is null) {
                return NotFound();
            }
            dbServiceTask.Code = serviceTask.Code;
            dbServiceTask.Description = serviceTask.Description;
            dbServiceTask.Hours = serviceTask.Hours;
            _serviceTaskRepo.Update(id, dbServiceTask);
            return RedirectToAction("Index");

        }

        // GET: ServiceTasksController/Delete/5
        public ActionResult Delete(int id) {
            ServiceTask? dbServiceTask = _serviceTaskRepo.GetById(id);
            if(dbServiceTask is null) {
                return NotFound();
            }
            return View(model: dbServiceTask);
        }

        // POST: ServiceTasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            if (!ModelState.IsValid) {
                return RedirectToAction(actionName: "Delete", routeValues: id);
            }
            ServiceTask? dbServiceTask = _serviceTaskRepo.GetById(id);
            if(dbServiceTask is null) {
                return NotFound();
            }
            _serviceTaskRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
