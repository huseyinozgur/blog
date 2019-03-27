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
    public class PostDetailConfiguration : IEntityTypeConfiguration<PostDetail>
    {
        public void Configure(EntityTypeBuilder<PostDetail> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasMany(q => q.Tags);
            builder.HasOne(q => q.CreatorUser).WithMany().HasForeignKey(q => q.Creator);
            builder.HasOne(q => q.LastEntryCreatorUser).WithMany().HasForeignKey(q => q.LastModifier);
        }
    }
}
