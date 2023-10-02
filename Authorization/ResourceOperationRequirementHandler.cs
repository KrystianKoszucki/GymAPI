using GymAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GymAPI.Authorization
{
    public class ResourceOperationRequirementHandler: AuthorizationHandler<ResourceOperationRequirement, Training>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Training training)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation== ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId= context.User.FindFirst(a => a.Type == ClaimTypes.NameIdentifier).Value;

            if (training.CreatedById== int.Parse(userId))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
