using AlAnon.Data;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlAnon.Areas.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;          
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            // How to migrate pending migrations
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                _db.Database.Migrate();
            }
            if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Usuario)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "lvergara06",
                Email = "lvergara06@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "9155389373",
                Nombre = "Luis",
                Grupo = "Viviendo En Plenitud"
            };

            _userManager.CreateAsync(adminUser, "lVeR_8520").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();
            var temps = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
               new Claim(JwtClaimTypes.Name,adminUser.UserName),
               new Claim(JwtClaimTypes.GivenName, adminUser.Nombre),
               new Claim("Grupo", adminUser.Grupo)
            }).Result;

        }
    }
}
