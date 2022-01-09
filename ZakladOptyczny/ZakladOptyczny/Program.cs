using Microsoft.EntityFrameworkCore;
using ZakladOptyczny.Models.Utilities.Database.Appointments;
using ZakladOptyczny.Models.Utilities.Database;
using ZakladOptyczny.Models.Utilities.Database.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext"));
});

builder.Services.AddScoped<IAppointmentManager, AppointmentManager>();
builder.Services.AddScoped<IUsersManager, UsersManager>();

builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
            {
                options.ClientId = "873675777253-vmv0h1vmfuilh717eodo76u028lah6j1.apps.googleusercontent.com";
                options.ClientSecret = "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";
                options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
            });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();