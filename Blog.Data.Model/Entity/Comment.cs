using Blog.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
