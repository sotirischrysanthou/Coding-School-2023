using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class MockCustomerRepo : IEntityRepo<Customer> {
        // Properties
        private readonly List<Customer> _customers;

        // Constructors
        public MockCustomerRepo() {
            _customers = new List<Customer> {
                new("Sotiris","Chrysanthou", "6911111111","123456789"){ Id = 0 },
                new("Christos","Kontorias", "6922222222","987654321") { Id = 1 },
                new("Grigoris","Avgenikos", "6933333333", "321654987") { Id = 2 }
            };
        }

        public void Add(Customer entity) {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            var lastId = _customers.OrderBy(todo => todo.Id).Last().Id;
            entity.Id = ++lastId;
            _customers.Add(entity);
        }

        public void Delete(int id) {
            var CustomerDb = _customers
                .Where(customer => customer.Id == id)
                .SingleOrDefault();
            if (CustomerDb is null)
                return;
            _customers.Remove(CustomerDb);
        }

        public bool EntityExists(Customer entity) {
            var CustomerDb = _customers
                .Where(customer => customer.Name == entity.Name
                && customer.Surname == entity.Surname
                && customer.Tin == entity.Tin
                && customer.Phone == entity.Phone)
                .SingleOrDefault();
            if (CustomerDb is null) {
                var Customer1Db = _customers
                .Where(customer => customer.Id == entity.Id)
                .SingleOrDefault();
                if (Customer1Db is null) {
                    return false;
                } else return true;
            } else return true;
        }

        public IList<Customer> GetAll() {
            return _customers;
        }

        public Customer? GetById(int id) {
            return _customers
                .Where(customer => customer.Id == id)
                .SingleOrDefault();
        }

        public void Update(int id, Customer entity) {
            var CustomerDb = _customers
                .Where(customer => customer.Id == id)
                .SingleOrDefault();
            if (CustomerDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            CustomerDb.Name = entity.Name;
            CustomerDb.Surname = entity.Surname;
            CustomerDb.Phone = entity.Phone;
            CustomerDb.Tin = entity.Tin;
        }
    }
}
