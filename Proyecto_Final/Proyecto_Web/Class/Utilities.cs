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
                CreateUserASP("admin@adminmail.com", "123456", "Admin", "Admin");
            }
        }

        public static void CreateUserASP(string email, string password, string username, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = username,
                Email = email,
                DateSignUp = DateTime.Now,
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

                
                CreateUserASP("demo@modamood.com", "123456", "Demo", "Reader");
                userclient = clientdb.FindByName("demo@modamood.com");
                var reader = new Reader
                {
                    ReaderId = userclient.Id
                };
                db.Readers.Add(reader);
                db.SaveChanges();
            }

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}