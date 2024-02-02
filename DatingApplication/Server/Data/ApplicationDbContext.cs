using DatingApplication.Server.Configurations.Entities;
using DatingApplication.Server.Models;
using DatingApplication.Shared.Domain;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Drawing;

namespace DatingApplication.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<DatingAppUser> DatingAppUsers {  get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new DatingAppUserSeedConfiguration());
            builder.ApplyConfiguration(new MatchSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());

        }
    }
}