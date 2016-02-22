using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeReferralApp.Models
{
    public class AuthenticationOutputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string JWTToken { get; set; }
    }
}