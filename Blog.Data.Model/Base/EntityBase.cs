using Blog.Data.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model.Base
{
    public abstract class EntityBase 
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public string Creator { get; set; }
        public string LastModifier { get; set; }
        public ApplicationUser CreatorUser { get; set; }
        public ApplicationUser LastEntryCreatorUser { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
