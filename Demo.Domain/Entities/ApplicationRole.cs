using Microsoft.AspNetCore.Identity;

namespace Demo.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public IList<ApplicationUserRole> UserRoles { get; set; }
}