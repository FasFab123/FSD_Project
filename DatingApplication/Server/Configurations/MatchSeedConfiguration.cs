using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApplication.Shared.Domain;


namespace DatingApplication.Server.Configurations.Entities
{
    public class MatchSeedConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasData(
                new Match
                {
                    Id = 1,
                    DatingAppUserInitiatorId = 1,
                    DatingAppUserRecieverId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                });
        }
    }
}
