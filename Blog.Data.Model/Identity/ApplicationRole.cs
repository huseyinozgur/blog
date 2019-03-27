using Microsoft.AspNetCore.Identity;

namespace Blog.Data.Model.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}
