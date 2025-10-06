using Cwk.Web.Auth;
using Cwk.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace Cwk.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var url = "https://localhost:7027";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });
            builder.Services.AddAuthorizationCore();
            builder.Services.AddMudServices();
            builder.Services.AddScoped<AuthenticationProviderJWT>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
            builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IReservationClientService, ReservationClientService>();
            await builder.Build().RunAsync();
        }
    }
}