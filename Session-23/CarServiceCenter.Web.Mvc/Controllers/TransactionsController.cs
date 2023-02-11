using CarServiceCenter.EF.Repositories;
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
        }

        // GET: TransactionController
        public ActionResult Index() {
            var transactions = _transactionRepo.GetAll();
            return View(model: transactions);
        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int id) {
            Transaction? dbTransaction = _transactionRepo.GetById(id);
            if(dbTransaction is null) {
                return NotFound();
            }
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
            return View();
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
            if(dbTransaction is null) {
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
            TransactionEditDto transaction = new TransactionEditDto() {
                Id = dbTransaction.Id,
                Date= dbTransaction.Date,
                ManagerId = dbTransaction.ManagerId,
                CarId= dbTransaction.CarId,
                CustomerId= dbTransaction.CustomerId

            };
            return View(model: transaction);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEditDto transaction) {
            if (!ModelState.IsValid) {
                return RedirectToAction(actionName: "Edit", routeValues: id);
            }
            Transaction? dbTransaction = _transactionRepo.GetById(transaction.Id);
            if(dbTransaction is null) {
                return NotFound();
            }
            dbTransaction.Date= transaction.Date;
            dbTransaction.ManagerId = transaction.ManagerId;
            dbTransaction.CarId = transaction.CarId;
            dbTransaction.CustomerId = transaction.CustomerId;
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
                return RedirectToAction(actionName: "Delete", routeValues: id);
            }
            Transaction? dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction is null) {
                return NotFound();
            }
            _transactionRepo.Delete(id);
            return RedirectToAction(actionName: "Index");
        }
    }
}
