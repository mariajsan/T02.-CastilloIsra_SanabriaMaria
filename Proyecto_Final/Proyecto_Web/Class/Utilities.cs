using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Proyecto_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Class
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("admin@adminmail.com");

            if (userAsp == null)
            {
                CreateUserASP("admin@adminmail.com", "123456", "Admin");
            }
        }

        public static void CreateUserASP(string email, string password, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                //FirstName = "Nombre",
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, rol);
        }

        internal static void CheckClientDefault()
        {
            var clientdb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userclient = clientdb.FindByName("demo@modamood.com");
            if (userclient == null)
            {
                userclient = clientdb.FindByName("demo@modamood.com");
                CreateUserASP("demo@modamood.com", "123456", "Reader");
                //var owner = new Owner
                //{
                //    OwnerId = userclient.Id
                //};
                //db.Owners.Add(owner);
                db.SaveChanges();
            }

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}