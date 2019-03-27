using Blog.Data.Model.Entity;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.CreatorUser).WithMany().HasForeignKey(q => q.Creator);
            builder.HasOne(q => q.LastEntryCreatorUser).WithMany().HasForeignKey(q => q.LastModifier);
        }
    }
}
