using System.Diagnostics;
using Climb2C.Questionnaires.sql.Repositories.Interfaces;
using Climb2C.Questionnaires.sql.Data;
using Microsoft.AspNetCore.Mvc;
using Questionnaires.Models;

namespace Questionnaires.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IForms _forms;

    public HomeController(ILogger<HomeController> logger, IForms forms)
    {
        _logger = logger;
        _forms = forms;
    }

    public async Task<IActionResult> Index()
    {
        List<Form> forms = new List<Form>();
        forms = await _forms.GetAll();
        return View(forms);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
