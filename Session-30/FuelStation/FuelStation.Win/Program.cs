using FuelStation.Win.Extensions;
using Unity;
using Unity.Injection;
using Unity.Resolution;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using FuelStation.EF.Repository;
using FuelStation.Model;
using Session_16.Win;
using FuelStation.Win.Transactions;
using FuelStation.Win.Items;
using FuelStation.Web.Blazor.Shared;

namespace FuelStation.Win {
    public static class Program {
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new UnityContainer();

            // Register HttpClient with BaseAddress
            container.RegisterFactory<HttpClient>(c => new HttpClient { BaseAddress = new Uri("https://localhost:5000") });
            var services = new ServiceCollection();
            services.AddAuthorizationCore();

            // Configure the dependency injection container

            // Register AuthenticationStateProvider
            container.RegisterType<CustomAuthenticationStateProvider>();

            // Register IServiceCollection instance
            container.RegisterInstance<IServiceCollection>(services);
            services.AddSingleton<LoginForm>();
            services.AddSingleton<MainMenuForm>();
            services.AddSingleton<CustomersForm>();
            services.AddSingleton<ItemsForm>();
            services.AddSingleton<TransactionsForm>();
            UserSession userSession = new UserSession();
            container.RegisterInstance<UserSession>(userSession);
            //services.AddScoped<IEntityRepo<Transaction>, TransactionRepo>();
            //services.AddScoped<IEntityRepo<Employee>, EmployeeRepo>();
            //services.AddScoped<IEntityRepo<Customer>, CustomerRepo>();
            //services.AddScoped<IEntityRepo<Item>, ItemRepo>();
            services.AddScoped<CustomAuthenticationStateProvider>();
            var serviceProvider = services.BuildServiceProvider();

            // Resolve LoginForm with HttpClient and AuthenticationStateProvider parameters
            var loginForm = container.Resolve<LoginForm>(
                new ParameterOverride("httpClient", container.Resolve<HttpClient>()),
                new ParameterOverride("authStateProvider", container.Resolve<CustomAuthenticationStateProvider>()),
                new ParameterOverride("userSession", container.Resolve<UserSession>())

            );
            var result = DialogResult.Continue;

            while (result == DialogResult.Continue) {
                // Show the login form
                result = loginForm.ShowDialog();
                container.RegisterInstance(loginForm.UserSession);
                while (result == DialogResult.OK) {
                    // If the user successfully logs in, show the main menu form
                    if (result == DialogResult.OK) {
                        var mainMenuForm = container.Resolve<MainMenuForm>(
                            new ParameterOverride("role", loginForm.Role));
                        result = mainMenuForm.ShowDialog();

                        switch (mainMenuForm.FormType) {
                            case Enums.FormType.Customers:
                                var customersForm = container.Resolve<CustomersForm>(
                                    new ParameterOverride("httpClient", container.Resolve<HttpClient>()),
                                    new ParameterOverride("authStateProvider", container.Resolve<CustomAuthenticationStateProvider>()),
                                    new ParameterOverride("userSession", container.Resolve<UserSession>())
                                );
                                result = customersForm.ShowDialog();
                                break;
                            case Enums.FormType.Items:
                                var itemsForm = container.Resolve<ItemsForm>(
                                    new ParameterOverride("httpClient", container.Resolve<HttpClient>()),
                                    new ParameterOverride("authStateProvider", container.Resolve<CustomAuthenticationStateProvider>()),
                                    new ParameterOverride("userSession", container.Resolve<UserSession>())
                                );
                                result = itemsForm.ShowDialog();
                                break;
                            case Enums.FormType.Transactions:
                                var transactionForm = container.Resolve<TransactionsForm>(
                                    new ParameterOverride("httpClient", container.Resolve<HttpClient>()),
                                    new ParameterOverride("authStateProvider", container.Resolve<CustomAuthenticationStateProvider>()),
                                    new ParameterOverride("userSession", container.Resolve<UserSession>())
                                );
                                result = transactionForm.ShowDialog();
                                break;
                            case Enums.FormType.Login:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}

