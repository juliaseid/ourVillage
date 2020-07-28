using YourVillage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace YourVillage.Authorization
{
  public class FamilyIsParentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Family>

  {
    UserManager<IdentityUser> _userManager;

    public FamilyIsParentAuthorizationHandler(UserManager<IdentityUser> userManager)

    {
      _userManager = userManager;
    }

    protected override Task
    HandleRequirementAsync(AuthorizationHandlerContext context,
    OperationAuthorizationRequirement requirement,
    Family resource)
    {
      var caregiverIds = resource.GetCaregiverIds();
      if (context.User == null || resource == null)
      {
        return Task.CompletedTask;
      }
      else if (resource.ParentId == _userManager.GetUserId(context.User))
      {
        context.Succeed(requirement);
      }
      else if (caregiverIds.Contains(_userManager.GetUserId(context.User)))
      {
        if (requirement.Name == IdentityConstants.ReadOperationName || requirement.Name == IdentityConstants.NoteOperationName)
        {
          context.Succeed(requirement);
        }
        else
        {
          return Task.CompletedTask;
        }
      }
      return Task.CompletedTask;

    }
  }
}