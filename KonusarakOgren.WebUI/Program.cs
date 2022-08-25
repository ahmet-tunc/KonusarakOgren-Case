using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IOC;
using KonusarakOgren.Business.DependencyResolvers.Autofac;
using KonusarakOgren.DataAccess.Concrete;
using KonusarakOgren.Entities.Concrete;
using KonusarakOgren.WebUI.ClaimProvider;
using KonusarakOgren.WebUI.Mapping;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });

builder.Services.AddAutoMapper(typeof(AppProfile));


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddDbContext<AppDbContext>(opts =>
//{
//    opts.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnectionString"]);
//});
builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddIdentity<AppUser,IdentityRole>(opts =>
{
    opts.Password.RequiredLength = 4;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IClaimsTransformation, ClaimProvider>();

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = new PathString("/Auth/Login");
    opts.LogoutPath = new PathString("/Auth/Login");
    opts.Cookie = new CookieBuilder
    {
        Name = "KonusarakOgren",
        HttpOnly = false,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    opts.ExpireTimeSpan = System.TimeSpan.FromDays(60);
    opts.SlidingExpiration = true;
});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Services.GetService<AppDbContext>().Database.EnsureCreated();

app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
