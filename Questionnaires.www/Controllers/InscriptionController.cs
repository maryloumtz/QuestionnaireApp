using System.Diagnostics;
using Climb2C.Questionnaires.sql.Data;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Questionnaires.Models;
using Microsoft.AspNetCore.Identity;

namespace Questionnaires.Controllers;

public class InscriptionController : Controller
{
    private readonly ILogger<InscriptionController> _Logger;

    private readonly IUsers _users;

    public InscriptionController(ILogger<InscriptionController> logger, IUsers users)
    {
        _Logger = logger;
        _users = users;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]

    public async Task<IActionResult> Index(string mail, string password, string name, string lastname, string passwordconfirm)
    {
        var user = await _users.GetByMail(mail);
        if (user != null)
        {
            ViewBag.Error = "Email déjà utilisé pour un autre compte, veuillez vous connecter";
            return View("Index");
        }
        if (password != passwordconfirm)
        {
            ViewBag.Error = "Le mot de passe saisi doit être identique";
            return View("Index");
        }
        if (password == passwordconfirm && user == null)
        {
            var hasher = new PasswordHasher<User>();
            var newUser = new User(mail, name, lastname, password);
            newUser.Password = hasher.HashPassword(newUser, password);

            await _users.InsertUser(newUser);
        }
        return RedirectToAction("Index", "Home");
    }
    
}