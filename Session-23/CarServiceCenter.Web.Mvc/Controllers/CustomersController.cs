using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class CustomersController : Controller {
        // Properties
        private readonly IEntityRepo<Customer> _customerRepo;

        // Constructors
        public CustomersController(IEntityRepo<Customer> customerRepo) {
            _customerRepo = customerRepo;
        }

        // GET: CustomersController
        public ActionResult Index() {
            var customers = _customerRepo.GetAll();
            return View(model: customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id) {
            Customer? customer = _customerRepo.GetById(id);
            if (customer is null) {
                return NotFound();
            }
            return View(model: customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateDto customer) {
            if (!ModelState.IsValid) {
                return View();
            }
            Customer dbCustomer = new Customer(customer.Name, customer.Surname, customer.Phone, customer.Tin);
            _customerRepo.Add(dbCustomer);
            return RedirectToAction("Index");
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id) {
            Customer? customer = _customerRepo.GetById(id);
            if (customer is null) {
                return NotFound();
            }
            return View(model: customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEditDto customer) {
            if (!ModelState.IsValid) {
                return View();
            }
            Customer dbCustomer = _customerRepo.GetById(id);
            if (dbCustomer is null) {
                return NotFound();
            }
            dbCustomer.Name = customer.Name;
            dbCustomer.Surname = customer.Surname;
            dbCustomer.Phone = customer.Phone;
            dbCustomer.Tin = customer.Tin;
            _customerRepo.Update(id, dbCustomer);
            return RedirectToAction("Index");
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id) {
            Customer customer = _customerRepo.GetById(id);
            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            if (!ModelState.IsValid) {
                return View();
            }
            Customer dbCustomer = _customerRepo.GetById(id);
            if (dbCustomer is null) {
                return NotFound();
            }
            _customerRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
