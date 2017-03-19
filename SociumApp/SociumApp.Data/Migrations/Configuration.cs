namespace SociumApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SociumApp.Data.EfSociumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SociumApp.Data.EfSociumDbContext";
        }

        protected override void Seed(SociumApp.Data.EfSociumDbContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
