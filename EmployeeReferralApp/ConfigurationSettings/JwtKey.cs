using System;
using ConfigInjector;

namespace EmployeeReferralApp.ConfigurationSettings
{
    public class JwtKey : ConfigurationSetting<Guid>
    {
        public string ToBase64EncodedString()
        {
            return Convert.ToBase64String(Value.ToByteArray());
        }
    }
}