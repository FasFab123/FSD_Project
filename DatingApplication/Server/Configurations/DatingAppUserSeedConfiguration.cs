using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApplication.Shared.Domain;


namespace DatingApplication.Server.Configurations.Entities
{
    public class DatingAppUserSeedConfiguration : IEntityTypeConfiguration<DatingAppUser>
    {
        public void Configure(EntityTypeBuilder<DatingAppUser> builder)
        {
            builder.HasData(
                new DatingAppUser
                {
                    Id = 1,
                    Username = "Felicia",
                    Age = 18,
                    Gender = "Female",
                    Email = "Felicia@gmail.com",
                    Password = "fel123",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new DatingAppUser
                {
                    Id = 2,
                    Username = "Jacob",
                    Age = 21,
                    Gender = "Male",
                    Email = "Jacob@gmail.com",
                    Password = "Jac123",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",

                }
                );
        }
    }
}
