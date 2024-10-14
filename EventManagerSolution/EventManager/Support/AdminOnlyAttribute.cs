using EventManager.dal.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventManager.Support;

public class AdminOnlyAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
        var userId = userManager.GetUserId(user);
        var currentUser = userManager.FindByIdAsync(userId).Result;

        if (currentUser == null || !currentUser.IsAdmin)
        {
            context.Result = new ForbidResult(); // Redirige vers une page d'erreur ou de refus d'accès
        }
    }
}