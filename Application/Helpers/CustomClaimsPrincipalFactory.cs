﻿using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        private readonly UserManager<AppUser> _userManager;
        public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _userManager = userManager;
        }
        public override async Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var identity = (ClaimsIdentity)principal.Identity;
            identity.AddClaims(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("FullName", user.FullName),
            new Claim("Avatar", user.Avatar ?? string.Empty),
            new Claim("Roles", string.Join(";", roles))
        });

            return principal;
        }

    }
}
