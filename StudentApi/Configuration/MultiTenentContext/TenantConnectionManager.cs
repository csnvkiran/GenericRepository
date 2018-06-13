using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StudentApi.Configuration
{
    public class TenantConnectionManager
    {
        HttpContext httpContext;

        public TenantConnectionManager(
            IHttpContextAccessor httpContentAccessor)
        {
            this.httpContext = httpContentAccessor.HttpContext;
        }

        /// <summary>
        /// Gets the name of the data base.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>db name</returns>
        public string GetConnectionString(IHttpContextAccessor httpContentAccessor)
        {
            string tenantId = "";
            tenantId = this.httpContext.Request.Headers["tenantid"].ToString();
            if (tenantId == "1")
            {


            }

            var dataBaseName = ""; //this.tenantConfigurationDictionary[Guid.Parse(tenantId)];

            if (dataBaseName == null)
            {
                throw new ArgumentNullException(nameof(dataBaseName));
            }

            return dataBaseName;
        }

    }
}
