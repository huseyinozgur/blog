using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Blog.Application
{
    public interface IPermissionProvider
    {
        ConcurrentDictionary<string, Permission> Permissions { get; }
    }


    public class Permission
    {
        public Claim Claim { get; }
        public string Name { get; }

        public Permission(string value, string name)
        {
            Claim = new Claim(PermissionClaimTypes.Permission, value);
            Name = name;
        }
    }

    public static class AuthorizationPolicies
    {
        public static void ConfigurePolicies(this IServiceCollection serviceDescriptors) {
            //IPermissionProvider service = (IPermissionProvider)serviceDescriptors.BuildServiceProvider().GetService(typeof(IPermissionProvider));

            //if (service is null) return;
            //ConcurrentDictionary<string, Permission>()


        }
    }
}
