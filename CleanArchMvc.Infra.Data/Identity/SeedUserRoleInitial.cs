﻿using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                };

                var result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                var result = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = "usuario@localhost",
                    Email = "usuario@localhost",
                    NormalizedUserName = "USUARIO@LOCALHOST",
                    NormalizedEmail = "USUARIO@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = _userManager.CreateAsync(applicationUser, "Numsey#2021").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(applicationUser, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = _userManager.CreateAsync(applicationUser, "Numsey#2021").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(applicationUser, "Admin").Wait();
                }
            }
        }
    }
}
