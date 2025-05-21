using System.Diagnostics;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Climb2C.Questionnaires.sql.Data;
using Microsoft.AspNetCore.Mvc;
using Questionnaires.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Questionnaires.Controllers;


public class ConnectionController : Controller 
{
    private readonly ILogger<ConnectionController> _Logger;

    private readonly IUsers _users;

    public ConnectionController(ILogger<ConnectionController> logger, IUsers users) 
    {
        _Logger = logger;
        _users = users;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string mail, string password)
    {
        var user = await _users.GetByMail(mail);
        if (user == null)
        {

            ViewBag.Error = "Email ou mot de passe incorrect";
            return View("Index");
        }

        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.Password, password);
        if (result != PasswordVerificationResult.Success)
        {
            ViewBag.Error = "Email ou mot de passe incorrect";
            return View("Index");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.ID_user.ToString()),
            new Claim(ClaimTypes.Name, user.Mail)
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        return RedirectToAction("Index", "Home");
    }
}