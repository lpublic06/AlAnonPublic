using AlAnonFront;
using AlAnonFront.Service;
using AlAnonFront.Service.IService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("AlAnonBaseAPIUrl")) });
builder.Services.AddScoped<IInicioService, InicioService>();
builder.Services.AddScoped<IGrupoService, GrupoService>();
builder.Services.AddScoped<IInfoService, InfoService>();
builder.Services.AddScoped<ICalendarioService, CalendarioService>();
builder.Services.AddScoped<IBoletinService, BoletinService>();
builder.Services.AddScoped<IInvitacionService, InvitacionService>();
builder.Services.AddScoped<IDocumentoService, DocumentoService>();
//builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddMudServices();


await builder.Build().RunAsync();
