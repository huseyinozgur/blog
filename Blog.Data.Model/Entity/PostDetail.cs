using Blog.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model.Entity
{
    public class PostDetail:EntityBase
    {
        public string Body { get; set; }
        public int PostId{ get; set; }
        public Post Post { get; set; }
        public ICollection<Tags> Tags { get; set; }
    }
}
