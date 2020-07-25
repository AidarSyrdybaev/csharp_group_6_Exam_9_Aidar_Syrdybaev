using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Contracts.EntitiesConfiguration
{
    public interface IEntityConfiguration<T> where T : class, IEntity
    {
        Action<EntityTypeBuilder<T>> ProvideConfigurationAction();
    }
}
