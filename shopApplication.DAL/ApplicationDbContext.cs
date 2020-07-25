using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shopApplication.DAL.Contracts.EntitiesConfiguration;
using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly IEntityConfigurationsContainer _entityConfigurationsContainer;

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Comment> Comments { get; set; }


        public ApplicationDbContext(
            DbContextOptions options,
            IEntityConfigurationsContainer entityConfigurationsContainer) : base(options)
        {
            _entityConfigurationsContainer = entityConfigurationsContainer;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
