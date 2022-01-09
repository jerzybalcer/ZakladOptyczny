using Microsoft.EntityFrameworkCore;
using ZakladOptyczny.Models.Utilities.Database.Appointments;
using ZakladOptyczny.Models.Utilities.Database;
using ZakladOptyczny.Models.Utilities.Database.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// register database context
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    // connection string in appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext"));
});

// services used to access database
builder.Services.AddScoped<IAppointmentManager, AppointmentManager>();
builder.Services.AddScoped<IUsersManager, UsersManager>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapRazorPages();

app.Run();

