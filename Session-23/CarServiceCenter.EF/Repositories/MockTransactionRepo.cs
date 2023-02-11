using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class MockTransactionRepo : IEntityRepo<Transaction> {
        // Properties
        private readonly List<Transaction> _transactions;
        private readonly List<TransactionLine> _transactionLines;
        private readonly List<Car> _cars;
        private readonly List<Customer> _customers;
        private readonly List<Manager> _managers;


        // Constructors
        public MockTransactionRepo() {
            MockTransactionLineRepo mockTransactionLineRepo = new MockTransactionLineRepo();
            MockCarRepo mockCarRepo = new MockCarRepo();
            MockCustomerRepo mockCustomerRepo = new MockCustomerRepo();
            MockManagerRepo mockManagerRepo = new MockManagerRepo();
            _transactionLines = mockTransactionLineRepo.GetAll().ToList();
            _cars = mockCarRepo.GetAll().ToList();
            _customers = mockCustomerRepo.GetAll().ToList();
            _managers = mockManagerRepo.GetAll().ToList();
            _transactions = new List<Transaction> {
                new(0){
                    Id = 0,
                    TransactionLines =new List<TransactionLine> {_transactionLines[0], _transactionLines[1]},
                    CarId = _cars[0].Id,
                    Car = _cars[0],
                    CustomerId = _customers[0].Id,
                    Customer = _customers[0],
                    ManagerId = _managers[0].Id,
                    Manager = _managers[0],
                    Date = new DateTime(year: 2022,month:12,day:1)
                },
                new(0){
                    Id = 1,
                    TransactionLines =new List<TransactionLine> {_transactionLines[2], _transactionLines[3]},
                    CarId = _cars[1].Id,
                    Car = _cars[1],
                    CustomerId = _customers[1].Id,
                    Customer = _customers[1],
                    ManagerId = _managers[1].Id,
                    Manager = _managers[1],
                    Date = new DateTime(year: 2023,month:1,day:12)
                },
                new(0){
                    Id = 2,
                    TransactionLines =new List<TransactionLine> {_transactionLines[4], _transactionLines[5]},
                    CarId = _cars[2].Id,
                    Car = _cars[2],
                    CustomerId = _customers[2].Id,
                    Customer = _customers[2],
                    ManagerId = _managers[0].Id,
                    Manager = _managers[0],
                    Date = new DateTime(year: 2023,month:2,day:3)
                }
            };
            foreach (Transaction transaction in _transactions) {
                transaction.UpdateTotalPrice();
                foreach (TransactionLine transactionLine in transaction.TransactionLines) {
                    transactionLine.TransactionId = transaction.Id;
                    transactionLine.Transaction = transaction;
                }
            }
        }

        public void Add(Transaction entity) {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            var lastId = _transactions.OrderBy(todo => todo.Id).Last().Id;
            entity.Id = ++lastId;
            _transactions.Add(entity);
        }

        public void Delete(int id) {
            var TransactionDb = _transactions
                .Where(transaction => transaction.Id == id)
                .SingleOrDefault();
            if (TransactionDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            _transactions.Remove(TransactionDb);
        }

        public bool EntityExists(Transaction entity) {
            var TransactionDb = _transactions
                .Where(transaction => transaction.CarId == entity.CarId
                && transaction.CustomerId == entity.CustomerId
                && transaction.ManagerId == entity.ManagerId
                && transaction.Date == entity.Date
                && transaction.TotalPrice == entity.TotalPrice)
                .SingleOrDefault();
            if (TransactionDb is null) {
                var Transaction1Db = _transactions
                .Where(transaction => transaction.Id == entity.Id)
                .SingleOrDefault();
                if (Transaction1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }

        public IList<Transaction> GetAll() {
            return _transactions;
        }

        public Transaction? GetById(int id) {
            return _transactions
                .Where(transaction => transaction.Id == id)
                .SingleOrDefault();
        }

        public void Update(int id, Transaction entity) {
            var TransactionDb = _transactions
                .Where(transaction => transaction.Id == id)
                .SingleOrDefault();
            if (TransactionDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            TransactionDb.Date = entity.Date;
            TransactionDb.CustomerId = entity.CustomerId;
            TransactionDb.CarId = entity.CarId;
            TransactionDb.ManagerId = entity.ManagerId;
            TransactionDb.TotalPrice = entity.TotalPrice;
        }
    }
}
