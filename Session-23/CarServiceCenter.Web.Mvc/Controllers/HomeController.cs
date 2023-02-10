using CarServiceCenter.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Model;
using System.Diagnostics;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityRepo<Car> _CarRepo;
        private readonly IEntityRepo<Customer> _CustomerRepo;
        private readonly IEntityRepo<Engineer> _EngineerRepo;
        private readonly IEntityRepo<Manager> _ManagerRepo;
        private readonly IEntityRepo<ServiceTask> _ServiceTaskRepo;
        private readonly IEntityRepo<TransactionLine> _TransactionLineRepo;
        private readonly IEntityRepo<Transaction> _TransactionRepo;
        public HomeController(ILogger<HomeController> logger
            , ILogger<HomeController> _log
            , IEntityRepo<Car> carRepo
            , IEntityRepo<Customer> customerRepo
            , IEntityRepo<Engineer> engineerRepo
            , IEntityRepo<Manager> managerRepo
            , IEntityRepo<ServiceTask> serviceTaskRepo
            , IEntityRepo<TransactionLine> transactionLineRepo
            , IEntityRepo<Transaction> transactionRepo) {
            _logger = logger;
            _CarRepo = carRepo;
            _CustomerRepo = customerRepo;
            _EngineerRepo = engineerRepo;
            _ManagerRepo = managerRepo;
            _ServiceTaskRepo = serviceTaskRepo;
            _TransactionLineRepo = transactionLineRepo;
            _TransactionRepo = transactionRepo;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}