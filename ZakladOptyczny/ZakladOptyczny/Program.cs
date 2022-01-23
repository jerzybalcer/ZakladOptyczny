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

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
                //options.ClientId = "96433081251-n3gafb9c592ch92uujkv2jd3h80rverd.apps.googleusercontent.com";
                //options.ClientSecret = "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";
                options.ClientId = "410992943637-0sou3flg89vk30ie2k4n59jthnmf62m0.apps.googleusercontent.com";
                options.ClientSecret = "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"; //<-- jerzy logon for azure
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
