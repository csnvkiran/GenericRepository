using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Configuration
{
    public class ConnectionSettings
    {
        /// <summary>
        /// Gets or sets the default connection.
        /// </summary>
        /// <value>
        /// The default connection.
        /// </value>
        public string StudentSqlDB { get; set; }

        public string StudentSqlDBT1 { get; set; }

        public string StudentMySqlDB { get; set; }
    }
}
