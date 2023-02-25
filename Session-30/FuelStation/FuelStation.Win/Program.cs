using FuelStation.Win.Extensions;
using Unity;
using Unity.Injection;
using Unity.Resolution;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

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

            // Register AuthenticationStateProvider
            container.RegisterType<CustomAuthenticationStateProvider>();

            // Register IServiceCollection instance
            container.RegisterInstance<IServiceCollection>(services);

            // Resolve LoginForm with HttpClient and AuthenticationStateProvider parameters
            Application.Run(container.Resolve<LoginForm>(
                new ParameterOverride("httpClient", container.Resolve<HttpClient>()),
                new ParameterOverride("authStateProvider", container.Resolve<CustomAuthenticationStateProvider>())
            ));
        }
    }
}

