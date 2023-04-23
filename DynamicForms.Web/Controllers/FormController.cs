using DynamicForm.Models;
using DynamicForms.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForms.Web.Controllers;

[Authorize]
public class FormController : Controller
{
    private readonly IInputFormService _inputFormService;

    public FormController(IInputFormService inputFormService)
    {
        _inputFormService = inputFormService;
    }

    [HttpGet]
    public async Task<IActionResult> GetFormList()
    {
        var formList = await _inputFormService.GetAllAsync();
        return View("FormList", formList);
    }

    [HttpPost]
    public async Task<IActionResult> SaveForm([FromBody] InputFormDto inputForm)
    {
        await _inputFormService.CreateAsync(inputForm);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> LoadForm(int id)
    {
        var form = await _inputFormService.GetAsync(id);
        return View("LoadForm", form);
    }
}