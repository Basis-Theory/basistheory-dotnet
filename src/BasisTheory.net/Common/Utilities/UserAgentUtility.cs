using System;
using System.Reflection;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> origin
using BasisTheory.net.Common.Entities;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace BasisTheory.net.Common.Utilities
{
    public static class UserAgentUtility
    {
        static UserAgentUtility()
        {
            Client = "BasisTheory.net";
            ClientVersion = Assembly.GetAssembly(typeof(UserAgentUtility)).GetName().Version.ToString(3);
        }

        public static string Client { get; }

        public static string ClientVersion { get; }

        public static string BuildUserAgentString(ApplicationInfo appInfo = null)
        {
            var userAgent = $"{Client}/{ClientVersion}";

            if (appInfo != null)
                userAgent += " " + appInfo.ToUserAgentString();

            return userAgent;
        }

        public static string BuildBtClientUserAgentString(ApplicationInfo appInfo = null)
        {
            var values = new Dictionary<string, object>
            {
                {"client", Client},
                {"client_version", ClientVersion}
            };

            try
            {
                var osVersion = OSDescription;
                values.Add("os_version", osVersion);
            }
            catch (Exception)
            {
                values.Add("os_version", "unknown");
            }

            try
            {
                values.Add("runtime_version", RuntimeInfoUtility.GetRuntimeVersion());
            }
            catch (Exception)
            {
                values.Add("runtime_version", "unknown/unknown");
            }

            if (appInfo != null)
                values.Add("application", appInfo);

            return JsonUtility.SerializeObject(values);
        }
<<<<<<< HEAD

    }
}
=======
        
    }
}
>>>>>>> origin
