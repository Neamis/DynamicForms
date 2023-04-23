using System.Diagnostics;
using DynamicForms.Application.Services;
using Microsoft.AspNetCore.Mvc;
using DynamicForms.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace DynamicForms.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IInputFormService _inputFormService;

    public HomeController(ILogger<HomeController> logger, IInputFormService inputFormService)
    {
        _logger = logger;
        _inputFormService = inputFormService;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        return View();
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