using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class MockTransactionLineRepo : IEntityRepo<TransactionLine> {
        // Properties
        private readonly List<TransactionLine> _transactionLines;
        private readonly List<ServiceTask> _serviceTasks;
        private readonly List<Engineer> _engineers;

        //Constructors
        public MockTransactionLineRepo() {
            MockServiceTaskRepo mockServiceTaskRepo = new MockServiceTaskRepo();
            MockEngineerRepo mockEngineerRepo = new MockEngineerRepo();
            _serviceTasks = mockServiceTaskRepo.GetAll().ToList();
            _engineers = mockEngineerRepo.GetAll().ToList();
            _transactionLines = new List<TransactionLine> {
                new(3, 44.5m) {
                    ServiceTaskId = _serviceTasks[0].Id,
                    ServiceTask = _serviceTasks[0],
                    EngineerId = _engineers[0].Id,
                    Engineer = _engineers[0]
                },
                new(3,44.5m) {
                    ServiceTaskId = _serviceTasks[1].Id,
                    ServiceTask = _serviceTasks[1],
                    EngineerId = _engineers[1].Id,
                    Engineer = _engineers[1]
                },
                new(3,44.5m) {
                    ServiceTaskId = _serviceTasks[2].Id,
                    ServiceTask = _serviceTasks[2],
                    EngineerId = _engineers[0].Id,
                    Engineer = _engineers[0]
                },
                new(3,44.5m) {
                    ServiceTaskId = _serviceTasks[0].Id,
                    ServiceTask = _serviceTasks[0],
                    EngineerId = _engineers[1].Id,
                    Engineer = _engineers[1]
                },
                new(3,44.5m) {
                    ServiceTaskId = _serviceTasks[1].Id,
                    ServiceTask = _serviceTasks[1],
                    EngineerId = _engineers[0].Id,
                    Engineer = _engineers[0]
                },
                new(3,44.5m) {
                    ServiceTaskId = _serviceTasks[2].Id,
                    ServiceTask = _serviceTasks[2],
                    EngineerId = _engineers[1].Id,
                    Engineer = _engineers[1]
                }
            };
        }

        public void Add(TransactionLine entity) {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            var lastId = _transactionLines.OrderBy(todo => todo.Id).Last().Id;
            entity.Id = ++lastId;
            _transactionLines.Add(entity);
        }

        public void Delete(int id) {
            var TransactionLineDb = _transactionLines
                .Where(transactionLine => transactionLine.Id == id)
                .SingleOrDefault();
            if (TransactionLineDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            _transactionLines.Remove(TransactionLineDb);
        }

        public bool EntityExists(TransactionLine entity) {
            var TransactionLineDb = _transactionLines
                .Where(transactionLine => transactionLine.ServiceTaskId == entity.ServiceTaskId
                && transactionLine.TransactionId == entity.TransactionId
                && transactionLine.Hours == entity.Hours
                && transactionLine.EngineerId == entity.EngineerId)
                .SingleOrDefault();
            if (TransactionLineDb is null) {
                var TransactionLine1Db = _transactionLines
                    .Where(transactionLine => transactionLine.Id == entity.Id)
                    .SingleOrDefault();
                if (TransactionLine1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }

        public IList<TransactionLine> GetAll() {
            return _transactionLines;
        }

        public TransactionLine? GetById(int id) {
            return _transactionLines
                .Where(transactionLine => transactionLine.Id == id)
                .SingleOrDefault();
        }

        public void Update(int id, TransactionLine entity) {
            var TransactionLineDb = _transactionLines
                .Where(transactionLine => transactionLine.Id == id)
                .SingleOrDefault();
            if (TransactionLineDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            TransactionLineDb.Price = entity.Price;
            TransactionLineDb.PricePerHour = entity.PricePerHour;
            TransactionLineDb.Hours = entity.Hours;
            TransactionLineDb.ServiceTaskId = entity.ServiceTaskId;
        }
    }
}
