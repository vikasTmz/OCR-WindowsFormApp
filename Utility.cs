using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HelloWorld
{
    class Utility
    {
        internal static string GetConnectionString()
        {
            //Util-2 Assume failure.
            string returnValue = null;

            //Util-3 Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["HelloWorld.Properties.Settings.Database1ConnectionString"];

            //If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
