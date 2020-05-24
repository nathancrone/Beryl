using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Beryl.Data;
using Beryl.Models;
using Microsoft.Extensions.Configuration;

namespace Beryl.Services
{
    public class SeedService : ISeedService
    {
        public readonly IConfiguration _config;
        public readonly UserManager<IdentityUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        private readonly BerylSqliteContext _sqliteContext;
        private readonly BerylInMemoryContext _inMemoryContext;
        public SeedService(IConfiguration config, BerylSqliteContext sqliteContext, BerylInMemoryContext inMemoryContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _sqliteContext = sqliteContext;
            _inMemoryContext = inMemoryContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            // create the admin role
            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = "Administrator"
                };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            // create the admin user
            if (_userManager.FindByNameAsync("Administrator").Result == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                IdentityResult result = _userManager.CreateAsync(user, _config.GetValue<string>("Settings:AdminPassword")).Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        public void SeedRedirects()
        {
            // delete all existing redirect rows
            foreach (var r in _inMemoryContext.Redirects)
            {
                _inMemoryContext.Redirects.Remove(r);
            }
            _inMemoryContext.SaveChanges();

            // copy all redirect rows from sqlite to in-memory
            foreach (var r in _sqliteContext.Redirects)
            {
                _inMemoryContext.Redirects.Add(new Redirect() { RedirectId = r.RedirectId, Url = r.Url });
            }
            _inMemoryContext.SaveChanges();
        }
    }
}