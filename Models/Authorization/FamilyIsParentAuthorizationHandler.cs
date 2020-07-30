using YourVillage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace YourVillage.Authorization
{
  public class FamilyIsParentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Family>

  {
    UserManager<ApplicationUser> _userManager;

    public FamilyIsParentAuthorizationHandler(UserManager<ApplicationUser> userManager)

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
      else if (context.User != null)
      {
        if (requirement.Name == IdentityConstants.AccessOperationName)
        {
          context.Succeed(requirement);
        }
      }
      else if (resource.ParentId == _userManager.GetUserId(context.User))
      {
        context.Succeed(requirement);
      }
      else if (caregiverIds.Contains(_userManager.GetUserId(context.User)))
      {
        if (requirement.Name == IdentityConstants.ReadOperationName ||
            requirement.Name == IdentityConstants.NoteOperationName ||
            requirement.Name == IdentityConstants.AccessOperationName)
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