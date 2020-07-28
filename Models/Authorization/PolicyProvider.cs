using System;
using System.Threading.Tasks;
// using YourVillage.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace YourVillage.Authorization
{
  public class VillageAuthPolicy : IAuthorizationPolicyProvider
  {
    public DefaultAuthorizationPolicyProvider defaultPolicyProvider { get; }
    public VillageAuthPolicy(IOptions<AuthorizationOptions> options)
    {
      defaultPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }
    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
      return defaultPolicyProvider.GetDefaultPolicyAsync();
    }

    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
      return defaultPolicyProvider.GetPolicyAsync(policyName);
    }
  }
}