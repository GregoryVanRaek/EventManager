using System.Security.Claims;
using Auth0.AspNetCore.Authentication;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.Mapper;
using EventManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers;

public class AccountController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;
    
    public async Task Login(string returnUrl = "/")
    {
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(returnUrl)
            .Build();

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    }
    
    public async Task Signup(string returnUrl = "/Account/Profil")
    {
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithParameter("screen_hint", "signup")
            .WithRedirectUri(returnUrl)
            .Build();

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    }

    [Authorize]
    public async Task Logout()
    {
        var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri(Url.Action("Index", "Home"))
            .Build();

        await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
    
    [Authorize]
    public IActionResult Profil()
    {
        string userEmail = User.Identity.Name;
        
        User user = _userService.GetByEmail(userEmail);

        if (user == null)
        {
            User newUser = new User
            {
                Id = Ulid.NewUlid().ToString(),
                Email = userEmail,
                FirstName = "",
                LastName = ""
            };
            
            _userService.Create(newUser);
            return View(newUser.toViewModel());
        }
        
        return View(user.toViewModel());
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Profil(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            _userService.Update(model.toEntity());
            TempData["SuccessMessage"] = "Your profile has been updated successfully.";
            return RedirectToAction(nameof(Profil));
        }
        
        return View(model);
    }
    
}