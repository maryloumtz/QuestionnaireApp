using System.Diagnostics;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Climb2C.Questionnaires.sql.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Questionnaires.Models;
using Climb2C.Questionnaires.sql.Repositories;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace Questionnaires.Controllers;

[Authorize]
public class FormsController : Controller
{
    private readonly ILogger<FormsController> _Logger;

    private readonly IForms _forms;

    private readonly IReponseUsers _reponseUsers;

    public FormsController(ILogger<FormsController> logger, IForms forms, IReponseUsers reponseUsers)
    {
        _Logger = logger;
        _forms = forms;
        _reponseUsers = reponseUsers;
    }

    public async Task<IActionResult> Index(int Id)
    {
        return View(await _forms.GetById(Id));
    }


    [HttpPost]
    public async Task<IActionResult> Index(Form form)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdStr))
        {
            return RedirectToAction("Index", "Connection");
        }
        var userID = int.Parse(userIdStr);
        foreach (var theme in form.Themes)
        {
            foreach (var question in theme.Questions)
            {
                await _reponseUsers.InsertReponseUser(
                    new ReponseUser(
                        form.ID_form
                        , question.ID_question
                        , userID
                        , question.frontSelectedUserResponse
                    )
                );
            }
        }
        return RedirectToAction("Index", "Home");
    }

}