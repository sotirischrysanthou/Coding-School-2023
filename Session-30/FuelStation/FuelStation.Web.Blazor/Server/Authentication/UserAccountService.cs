using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Authorization {
    public class UserAccountService {
        // Properties
        private List<Account>? _accounts;

        // Constructors
        public UserAccountService() {
            _accounts = GetAccounts().Result;
        }

        private async Task<List<Account>?> GetAccounts() {
            Uri baseUrl = new Uri("https://localhost:5000");
            HttpClient httpClient = new HttpClient() {
                BaseAddress = baseUrl
            };
            AccountRepo accountRepo = new AccountRepo();
            var accounts = await accountRepo.GetAll();
            foreach(Account account in accounts) {
                account.Employee.Account = null!;
            }
            return accounts.ToList();
        }

        public Account? GetUserAccountByUsername(string username) {
            return _accounts.FirstOrDefault(a => a.Username == username);
        }
    }
}
