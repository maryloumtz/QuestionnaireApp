using Climb2C.Questionnaires.sql;
using Climb2C.Questionnaires.sql.Repositories;
using Climb2C.Questionnaires.sql.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<DapperDbContext>();
builder.Services.AddTransient<
    Climb2C.Questionnaires.sql.Repositories.Interfaces.IForms
    , Climb2C.Questionnaires.sql.Repositories.Forms
>();

builder.Services.AddTransient<
    Climb2C.Questionnaires.sql.Repositories.Interfaces.IThemes
    , Climb2C.Questionnaires.sql.Repositories.Themes
>();

builder.Services.AddTransient<
    Climb2C.Questionnaires.sql.Repositories.Interfaces.IQuestions
    , Climb2C.Questionnaires.sql.Repositories.Questions
>();

builder.Services.AddTransient<
    Climb2C.Questionnaires.sql.Repositories.Interfaces.IReponsePossibles
    , Climb2C.Questionnaires.sql.Repositories.ReponsePossibles
>();

builder.Services.AddTransient<
    Climb2C.Questionnaires.sql.Repositories.Interfaces.IUsers
    , Climb2C.Questionnaires.sql.Repositories.Users
>();

builder.Services.AddTransient<
    Climb2C.Questionnaires.sql.Repositories.Interfaces.IReponseUsers
    , Climb2C.Questionnaires.sql.Repositories.ReponseUsers
>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Connection/Index";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inscription}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
