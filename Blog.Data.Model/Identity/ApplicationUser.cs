using System;
using System.Collections.Generic;
using System.ComponentModel;
using Blog.Data.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace Blog.Data.Model.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }
    }
}
