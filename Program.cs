using Library;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<LibraryContext>() // Povezuje Identity bazom podataka
.AddDefaultTokenProviders(); // Potrebno za reset lozinke, verifikaciju naloga itd


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//builder.Services.AddDefaultIdentity<IdentityUser>(options=>options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryContext>();
//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryContext>();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bibliotekari}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try {
        SeedData.Initialize(services);
    }
    catch(Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError("Greska prilikom inicijalizacije podataka");
    }
}
app.MapRazorPages();
app.Run();
