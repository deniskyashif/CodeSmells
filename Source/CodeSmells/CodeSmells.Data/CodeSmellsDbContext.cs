namespace CodeSmells.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class CodeSmellsDbContext : IdentityDbContext<User>
    {
        public CodeSmellsDbContext()
            : base("CodeSmellsDb", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeSmellsDbContext, Configuration>());
        }

        public static CodeSmellsDbContext Create()
        {
            return new CodeSmellsDbContext();
        }
    }
}