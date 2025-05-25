using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Ultimate.WebApp;
using Ultimate.WebApp.Helpers;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Listpackages;
using Ultimate.WebApp.ListPackagesByUserId;
using Ultimate.WebApp.Model;
using Ultimate.WebApp.Pages.Bot;
using Ultimate.WebApp.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddSingleton<ClientSingle>();
builder.Services.AddScoped<IAutomessageService, AutomessageService>();
builder.Services.AddScoped<IEventsService, EventsService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<ISMenuService, SMenuService>();
builder.Services.AddScoped<ITextService, TextService>();
builder.Services.AddScoped<IBotService, BotService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPackagesService, PackagesService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IPeriodService, PeriodService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IListPackagesService, ListPackagesService>();
builder.Services.AddScoped<IListPackagesByUserId, ListPackagesByUserId>();
builder.Services.AddScoped<ISendVerifyCodeService, SendVerifyCodeService>();
builder.Services.AddScoped<IReportCollectionServices, ReportCollectionServices>();
builder.Services.AddScoped<IEncodingReportService, EncodingReportService>();
builder.Services.AddScoped<IReportTemplateService, ReportTemplateService>();
builder.Services.AddScoped<IAdminDashboardService, AdminDashboardService>();
builder.Services.AddScoped<INotificationServices, NotificationServices>();
builder.Services.AddScoped(sp => new CustomHttp { HttpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) } });
builder.Services.AddScoped(sp => new HttpClient(new CustomHttpMessageHandler()) { BaseAddress = new Uri(builder.Configuration["BaseApiUrl"], UriKind.Absolute) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddLocalization();
builder.Services.RegisterIntlTelInput();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

Global.Services = app.Services;
Application.App = app;

await app.SetDefaultCulture();

await app.RunAsync();