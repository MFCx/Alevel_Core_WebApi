﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal,string claimsType)
        {
            var result = claimsPrincipal?.FindAll(claimsType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string> ClaimsRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
