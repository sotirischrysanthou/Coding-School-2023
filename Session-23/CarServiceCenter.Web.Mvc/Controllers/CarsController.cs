using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class CarsController : Controller {
        // Properties
        private readonly IEntityRepo<Car> _carRepo;

        // Constructors
        public CarsController(IEntityRepo<Car> carRepo) {
            _carRepo = carRepo;
        }

        // GET: CarsController
        public ActionResult Index() {
            var dbCars = _carRepo.GetAll();
            return View(dbCars);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id) {
            Car? dbCar = _carRepo.GetById(id);
            if (dbCar is null) {
                return NotFound();
            }
            return View(model: dbCar);
        }

        // GET: CarsController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreateDto car) {
            if (!ModelState.IsValid) {
                return View();
            }
            Car dbCar = new Car(car.Brand, car.Model, car.CarRegistrationNumber);
            _carRepo.Add(dbCar);
            return RedirectToAction("Index");
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id) {
            Car? dbCar = _carRepo.GetById(id);
            if (dbCar is null) {
                return NotFound();
            }
            CarEditDto car = new CarEditDto {
                Id = dbCar.Id,
                Brand = dbCar.Brand,
                Model = dbCar.Model,
                CarRegistrationNumber = dbCar.CarRegistrationNumber,
            };
            return View(model: car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarEditDto car) {
            if (!ModelState.IsValid) {
                return View(model: car);
            }
            Car? dbCar = _carRepo.GetById(id);
            if (dbCar is null) {
                return NotFound();
            }
            dbCar.Brand = car.Brand;
            dbCar.Model = car.Model;
            dbCar.CarRegistrationNumber = car.CarRegistrationNumber;
            _carRepo.Update(id, dbCar);
            return RedirectToAction("Index");
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id) {
            Car? car = _carRepo.GetById(id);
            if (car is null) {
                return NotFound();
            }
            return View(model: car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            if(!ModelState.IsValid){
                return RedirectToAction(actionName: "Delete", routeValues: id);
            }
            Car? dbCar = _carRepo.GetById(id);
            if (dbCar is null) {
                return NotFound();
            }
            _carRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
