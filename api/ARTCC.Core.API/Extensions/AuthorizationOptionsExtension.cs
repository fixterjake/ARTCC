using ARTCC.Core.Shared.Utils;
using Microsoft.AspNetCore.Authorization;

namespace ARTCC.Core.API.Extensions;

public static class AuthorizationOptionsExtension
{
    public static void AddAuthPolicies(this AuthorizationOptions options)
    {
        options.AddMemberPolicy();
    }

    public static void AddMemberPolicy(this AuthorizationOptions options)
    {
        options.AddClaimPolicy("IsMember", "IsMember", $"{true}");
    }

    public static void AddCreateAirportPolicy(this AuthorizationOptions options)
    {
        options.AddRolePolicy("Create.Airport", Constants.PERMISSION_CREATE_AIRPORT);
    }

    public static void AddRolePolicy(this AuthorizationOptions options, string policyName, string permission)
    {
        options.AddPolicy(policyName, policy => { _ = policy.RequireRole(new string[] { permission }); });
    }

    public static void AddClaimPolicy(this AuthorizationOptions options, string policyName, string claim,
        string value)
    {
        options.AddPolicy(policyName, policy => { _ = policy.RequireClaim(claim, value); });
    }
}
