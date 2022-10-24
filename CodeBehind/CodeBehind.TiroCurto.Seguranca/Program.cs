//***CODE BEHIND - BY RODOLFO.FONSECA***//

using AspNetCoreRateLimit;
using CodeBehind.TiroCurto.Seguranca.Core;
using CodeBehind.TiroCurto.Seguranca.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var s = builder.Services;

s.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
s.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
s.AddTransient(typeof(GoogleCaptchaService));
s.AddControllersWithViews();


s.AddMemoryCache();
s.Configure<IpRateLimitOptions>(options =>
{
    options.EnableEndpointRateLimiting = true;
    options.StackBlockedRequests = false;
    options.HttpStatusCode = 429;
    options.RealIpHeader = "X-Real-IP";
    options.ClientIdHeader = "X-ClientId";
    options.GeneralRules = new List<RateLimitRule>
        {
            new RateLimitRule
            {
                Endpoint = "GET:/Home/TesteLimiteAcesso",
                Period = "10s",
                Limit = 2,
            }
        };
});
s.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
s.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
s.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
s.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
s.AddInMemoryRateLimiting();

s.Configure<GoogleCaptchaConfig>(builder.Configuration.GetSection("GoogleReCaptcha"));

var app = builder.Build();

app.UseIpRateLimiting();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
