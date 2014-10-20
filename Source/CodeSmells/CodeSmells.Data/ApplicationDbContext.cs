namespace CodeSmells.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using CodeSmells.Data.Migrations;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CodeSmellsDb", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}