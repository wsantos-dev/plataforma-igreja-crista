using System;
using Microsoft.AspNetCore.Identity;
using PlataformaRedencao.Infra.Identity.Entities;

namespace PlataformaRedencao.Infra.Identity.Seed;

public static class IdentitySeed
{
    public static async Task SeedAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
}
