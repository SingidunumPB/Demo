using Demo.Application.Common.Interfaces;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Demo.Infrastructure.Identity;

public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{

    public async Task CreateRoleAsync(string role)
    {
        var alreadyExist = await roleManager.RoleExistsAsync(role);

        if (!alreadyExist)
        {
            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = role,
                NormalizedName = role.Normalize()
            });
        }
    }
}
