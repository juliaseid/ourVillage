using YourVillage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace YourVillage.Authorization
{
  public class FamilyIsParentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Family>

  {
    UserManager<ApplicationUser> _userManager;
    private readonly YourVillageContext _db;

    public FamilyIsParentAuthorizationHandler(UserManager<ApplicationUser> userManager, YourVillageContext db)

    {
      _userManager = userManager;
      _db = db;
    }

    protected override Task
    HandleRequirementAsync(AuthorizationHandlerContext context,
    OperationAuthorizationRequirement requirement,
    Family resource)
    {
      var caregiverIds = resource.GetCaregiverIds();
      if (resource.ParentId == _userManager.GetUserId(context.User))
      {
        context.Succeed(requirement);
      }

      else if (caregiverIds.Contains(_userManager.GetUserId(context.User)))
      {
        if (requirement.Name == IdentityConstants.ReadOperationName ||
            requirement.Name == IdentityConstants.NoteOperationName)
        {
          context.Succeed(requirement);
        }
        // else
        // {
        //   return Task.CompletedTask;
        // }

        else if (context.User == null || resource == null)
        {
          return Task.CompletedTask;
        }

      }
      return Task.CompletedTask;

    }
  }
}