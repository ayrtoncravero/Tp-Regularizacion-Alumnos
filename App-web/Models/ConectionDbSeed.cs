using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_web.Models
{
    public class ConectionDbSeed
    {
        public static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager)
        {
            //Esto es lo que no me dejaba crear
            //if (roleManager.Roles.Any())
            //{
                await roleManager.CreateAsync(new IdentityRole(Roles.AdminRole));
                await roleManager.CreateAsync(new IdentityRole(Roles.EstudianteRole));
            //}
    }
        public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager)
        {
            var userAdmin = userManager.Users.Where(x => x.Email == Roles.MailAdminRole).FirstOrDefault();
            if (userAdmin != null) return;

            userAdmin = new IdentityUser
            {
                UserName = Roles.MailAdminRole,
                Email = Roles.MailAdminRole,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            await userManager.CreateAsync(userAdmin, "Clave1");
            await userManager.AddToRoleAsync(userAdmin, Roles.AdminRole); 
        }
    }
}
