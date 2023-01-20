using Microsoft.AspNetCore.Identity;
using Serilog;
using Serilog.Formatting.Compact;

using Microsoft.EntityFrameworkCore;
using RoleBaseDemo.Data;
using RoleBaseDemo.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(new RenderedCompactJsonFormatter()).WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RoleBaseDemoContext>(options =>
                {
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                    options.UseSnakeCaseNamingConvention();
                });

string identityConnectionString = builder.Configuration.GetConnectionString("RoleBaseDemoIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'RoleBaseDemoIdentityDbContextConnection' not found.");
builder.Services.AddDbContext<RoleBaseDemoIdentityDbContext>(options =>
                {
                    options.UseMySql(identityConnectionString, ServerVersion.AutoDetect(identityConnectionString));
                    options.UseSnakeCaseNamingConvention();
                });
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<RoleBaseDemoIdentityDbContext>();
// builder.Services.AddAuthentication("CookieAuthentication")
//                  .AddCookie("CookieAuthentication", config =>
//                  {
//                      config.Cookie.Name = "UserLoginCookie";
//                      config.LoginPath = "/Account/Login";
//                      config.AccessDeniedPath = "/Account/AccessDenied";
//                  });
// builder.Services.AddAuthorization(config =>
//             {
//                 var userAuthPolicyBuilder = new AuthorizationPolicyBuilder();
//                 config.DefaultPolicy = userAuthPolicyBuilder
//                                     .RequireAuthenticatedUser()
//                                     .RequireClaim(ClaimTypes.DateOfBirth)
//                                     .Build();
//                 config.AddPolicy("UserPolicy", policy => policy.RequireRole("User").Build());
//             });
builder.Services.AddControllersWithViews();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// app.MapControllerRoute(
//     name: "Identity",
//     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
