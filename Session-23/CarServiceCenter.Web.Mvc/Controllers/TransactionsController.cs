using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Functions;
using CarServiceCenter.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class TransactionsController : Controller {
        // Properties
        private readonly IEntityRepo<Car> _carRepo;
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Engineer> _engineerRepo;
        private readonly IEntityRepo<Manager> _managerRepo;
        private readonly IEntityRepo<ServiceTask> _serviceTaskRepo;
        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private WorkloadManagment _workloadManagment;

        // Constructors
        public TransactionsController(IEntityRepo<Car> carRepo
            , IEntityRepo<Customer> customerRepo
            , IEntityRepo<Engineer> engineerRepo
            , IEntityRepo<Manager> managerRepo
            , IEntityRepo<ServiceTask> serviceTaskRepo
            , IEntityRepo<TransactionLine> transactionLineRepo
            , IEntityRepo<Transaction> transactionRepo) {
            _carRepo = carRepo;
            _customerRepo = customerRepo;
            _engineerRepo = engineerRepo;
            _managerRepo = managerRepo;
            _serviceTaskRepo = serviceTaskRepo;
            _transactionLineRepo = transactionLineRepo;
            _transactionRepo = transactionRepo;
            _workloadManagment = new WorkloadManagment();
            _workloadManagment.CalculateWorkDays();
        }

        // GET: TransactionController
        public ActionResult Index() {
            var transactions = _transactionRepo.GetAll();
            return View(model: transactions);
        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int id) {
            Transaction? dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction is null) {
                return NotFound();
            }
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            dbTransaction.TransactionLines = transactionLineRepo.GetAllWithTransactionID(id).ToList();
            return View(model: dbTransaction);
        }

        // GET: TransactionController/Create
        public ActionResult Create() {
            List<Customer> customers = _customerRepo.GetAll().ToList();
            var selectCustomersList = customers.Select(c => new SelectListItem {
                Value = c.Id.ToString(),
                Text = c.Name + " " + c.Surname
            });

            List<Manager> managers = _managerRepo.GetAll().ToList();
            var selectManagersList = managers.Select(m => new SelectListItem {
                Value = m.Id.ToString(),
                Text = m.Name + " " + m.Surname
            });

            List<Car> cars = _carRepo.GetAll().ToList();
            var selectCarsList = cars.Select(c => new SelectListItem {
                Value = c.Id.ToString(),
                Text = c.Brand + " " + c.Model
            });
            ViewBag.Managers = selectManagersList;
            ViewBag.Customers = selectCustomersList;
            ViewBag.Cars = selectCarsList;
            TransactionCreateDto transactionCreateDto = new TransactionCreateDto() {
            Date= DateTime.Now
            };
            return View(model: transactionCreateDto);
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreateDto transaction) {
            if (!ModelState.IsValid) {
                return View();
            }
            Transaction dbTransaction = new Transaction() {
                Date = transaction.Date,
                TotalPrice = 0,
                CustomerId = transaction.CustomerId,
                ManagerId = transaction.ManagerId,
                CarId = transaction.CarId
            };
            _transactionRepo.Add(dbTransaction);
            return RedirectToAction("Index");
        }

        // GET: TransactionController/Edit/5
        public ActionResult Edit(int id) {
            Transaction? dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction is null) {
                return NotFound();
            }
            List<Customer> customers = _customerRepo.GetAll().ToList();
            var selectCustomersList = customers.Select(c => new SelectListItem {
                Value = c.Id.ToString(),
                Text = c.Name + " " + c.Surname
            });

            List<Manager> managers = _managerRepo.GetAll().ToList();
            var selectManagersList = managers.Select(m => new SelectListItem {
                Value = m.Id.ToString(),
                Text = m.Name + " " + m.Surname
            });

            List<Car> cars = _carRepo.GetAll().ToList();
            var selectCarsList = cars.Select(c => new SelectListItem {
                Value = c.Id.ToString(),
                Text = c.Brand + " " + c.Model
            });
            ViewBag.Managers = selectManagersList;
            ViewBag.Customers = selectCustomersList;
            ViewBag.Cars = selectCarsList;
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            TransactionEditDto transaction = new TransactionEditDto() {
                Id = dbTransaction.Id,
                Date = dbTransaction.Date,
                ManagerId = dbTransaction.ManagerId,
                CarId = dbTransaction.CarId,
                CustomerId = dbTransaction.CustomerId,
                TransactionLines = transactionLineRepo.GetAllWithTransactionID(id).ToList(),
            };
            return View(model: transaction);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEditDto transaction) {
            if (!ModelState.IsValid) {
                return RedirectToAction(actionName: "Edit", routeValues: new { id = id });
            }
            Transaction? dbTransaction = _transactionRepo.GetById(transaction.Id);
            if (dbTransaction is null) {
                return NotFound();
            }
            dbTransaction.Date = transaction.Date;
            dbTransaction.ManagerId = transaction.ManagerId;
            dbTransaction.CarId = transaction.CarId;
            dbTransaction.CustomerId = transaction.CustomerId;
            dbTransaction.UpdateTotalPrice();
            _transactionRepo.Update(id, dbTransaction);
            return RedirectToAction(actionName: "Index");
        }

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id) {
            var dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction is null) {
                return NotFound();
            }
            return View(model: dbTransaction);
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            if (!ModelState.IsValid) {
                return RedirectToAction(actionName: "Delete", routeValues: new { id = id });
            }
            Transaction? dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction is null) {
                return NotFound();
            }
            _transactionRepo.Delete(id);
            return RedirectToAction(actionName: "Index");
        }

        //------------------Transaction Lines--------------------------------//

        // GET: TransactionController/Details/5
        public ActionResult DetailsLine(int id) {
            TransactionLine? dbTransactionLine = _transactionLineRepo.GetById(id);
            if (dbTransactionLine is null) {
                return NotFound();
            }
            return View(model: dbTransactionLine);
        }
        // GET: TransactionController/CreateLine
        public ActionResult CreateLine(int transactionId) {
            List<Engineer> engineers = _engineerRepo.GetAll().ToList();
            var selectEngineersList = engineers.Select(e => new SelectListItem {
                Value = e.Id.ToString(),
                Text = e.Name + " " + e.Surname
            });

            List<ServiceTask> serviceTasks = _serviceTaskRepo.GetAll().ToList();
            var selectServiceTasksList = serviceTasks.Select(s => new SelectListItem {
                Value = s.Id.ToString(),
                Text = s.Code
            });


            ViewBag.Engineers = selectEngineersList;
            ViewBag.ServiceTasks = selectServiceTasksList;
            TransactionLineCreateDto transactionLineCreateDto = new TransactionLineCreateDto() {
                TransactionId = transactionId
            };

            return View(model: transactionLineCreateDto);
        }

        // POST: TransactionController/CreateLine
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLine(TransactionLineCreateDto transactionLine) {
            if (!ModelState.IsValid) {
                return View();
            }
            ServiceTask? serviceTask = _serviceTaskRepo.GetById(transactionLine.ServiceTaskId);
            if (serviceTask == null) {
                return RedirectToAction(actionName: "CreateLine", routeValues: new { id = transactionLine.TransactionId });
            }
            decimal hours = serviceTask.Hours;
            TransactionLine dbTransactionLine = new TransactionLine() {
                ServiceTaskId = transactionLine.ServiceTaskId,
                EngineerId = transactionLine.EngineerId,
                PricePerHour = 44.5m,
                Hours = hours,
                Price = 44.5m * hours,
                TransactionId = transactionLine.TransactionId
            };
            _transactionLineRepo.Add(dbTransactionLine);
            Transaction? transaction = _transactionRepo.GetById(dbTransactionLine.TransactionId);
            if (transaction is not null) { 
                transaction.UpdateTotalPrice();
            }
            return RedirectToAction(actionName: "Edit", routeValues: new { id = transactionLine.TransactionId });
        }
        // GET: TransactionController/Edit/5
        public ActionResult EditLine(int id) {
            TransactionLine? dbTransactionLine = _transactionLineRepo.GetById(id);
            if (dbTransactionLine is null) {
                return NotFound();
            }
            List<Engineer> engineers = _engineerRepo.GetAll().ToList();
            var selectEngineersList = engineers.Select(c => new SelectListItem {
                Value = c.Id.ToString(),
                Text = c.Name + " " + c.Surname
            });
            List<ServiceTask> serviceTasks = _serviceTaskRepo.GetAll().ToList();
            var selectServiceTasksList = serviceTasks.Select(s => new SelectListItem {
                Value = s.Id.ToString(),
                Text = s.Code
            });


            ViewBag.Engineers = selectEngineersList;
            ViewBag.ServiceTasks = selectServiceTasksList;
            TransactionLineEditDto transactionLine = new TransactionLineEditDto() {
                Id = dbTransactionLine.Id,
                PricePerHour =dbTransactionLine.PricePerHour,
                ServiceTaskId = dbTransactionLine.ServiceTaskId,
                EngineerId = dbTransactionLine.EngineerId,
            };
            return View(model: transactionLine);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLine(int id, TransactionLineEditDto transactionLine) {
            if (!ModelState.IsValid) {
                return RedirectToAction(actionName: "Edit", routeValues: new { id = id });
            }
            TransactionLine? dbTransactionLine = _transactionLineRepo.GetById(transactionLine.Id);
            if (dbTransactionLine is null) {
                return NotFound();
            }
            ServiceTask? serviceTask = _serviceTaskRepo.GetById(transactionLine.ServiceTaskId);
            if (serviceTask == null) {
                return RedirectToAction(actionName: "EditLine", routeValues: new { id = transactionLine.Id });
            }
            decimal hours = serviceTask.Hours;

            dbTransactionLine.ServiceTaskId = transactionLine.ServiceTaskId;
            dbTransactionLine.EngineerId = transactionLine.EngineerId;
            dbTransactionLine.PricePerHour = 44.5m;
            dbTransactionLine.Hours = hours;
            dbTransactionLine.Price = 44.5m * hours;
            _transactionLineRepo.Update(id, dbTransactionLine);
            Transaction? transaction = _transactionRepo.GetById(dbTransactionLine.TransactionId);
            if (transaction is not null) {
                transaction.UpdateTotalPrice();
            }
            return RedirectToAction(actionName: "Edit", routeValues: new { id = dbTransactionLine.TransactionId });
        }
    }
}
