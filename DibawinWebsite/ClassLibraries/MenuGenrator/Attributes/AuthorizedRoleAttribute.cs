using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.ClassLibraries.MenuGenrator.Attributes
{
    public class AuthorizedRoleAttribute : AuthorizeAttribute
    {
        public AuthorizedRoleAttribute(string role)
        {
            Role = role;
        }

        public string Role { get; private set; }
    }
}
