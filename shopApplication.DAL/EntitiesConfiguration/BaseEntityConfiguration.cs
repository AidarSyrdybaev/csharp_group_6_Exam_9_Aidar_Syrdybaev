using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopApplication.DAL.Contracts.EntitiesConfiguration;
using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.EntitiesConfiguration
{
    public class BaseEntityConfiguration<T> : IEntityConfiguration<T> where T : class, IEntity
    {
        public Action<EntityTypeBuilder<T>> ProvideConfigurationAction()
        {
            return ConfigureEntity;
        }

        private void ConfigureEntity(EntityTypeBuilder<T> builder)
        {
            ConfigureProperties(builder);
            ConfigurePrimaryKeys(builder);
            ConfigureForeignKeys(builder);
        }

        protected virtual void ConfigureProperties(EntityTypeBuilder<T> builder) { }

        protected virtual void ConfigurePrimaryKeys(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
        }

        protected virtual void ConfigureForeignKeys(EntityTypeBuilder<T> builder) { }

    }
}
