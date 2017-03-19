using Microsoft.AspNet.Identity.EntityFramework;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Data
{
    public class EfSociumDbContext : IdentityDbContext<ApplicationUser>, IEfSociumDbContext
    {
        public EfSociumDbContext() : base("SociumAppLocal")
        {

        }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Option> Options { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEfModel
        {
            return base.Set<TEntity>();
        }

        public static EfSociumDbContext Create()
        {
            return new EfSociumDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<ApplicationUser>()
                        .HasMany<Vote>(s => s.MyVotes)
                        .WithMany(c => c.LikedUsers)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserId");
                            cs.MapRightKey("VoteId");
                            cs.ToTable("UserVote");
                        });
        }
    }
}
