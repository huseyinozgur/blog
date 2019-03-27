using Blog.Data.Model.Base;
using Blog.Data.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model.Entity
{
    public class Post:EntityBase
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
