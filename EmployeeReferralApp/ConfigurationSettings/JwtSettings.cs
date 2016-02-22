using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeReferralApp.ConfigurationSettings
{
    public class JwtSettings
    {
        public JwtAllowedAudience JwtAllowedAudience { get; set; }
        public JwtIssuer JwtIssuer { get; set; }
        public JwtKey JwtKey { get; set; }
    }
}