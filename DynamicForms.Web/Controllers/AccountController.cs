using DynamicForms.Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForms.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View("UserLogin");
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password,
                false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                return View("UserLogin");
            }
        }
        else
        {
            ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
            return View("UserLogin");
        }

        return View("UserLogin");
    }
}