using System;
using System.Collections.Generic;
using System.Text;

namespace GR.Core.Interface
{
    /// <summary>
    /// Referece : http://techbrij.com/generic-repository-unit-of-work-entity-framework-unit-testing-asp-net-mvc
    /// </summary>

    public interface IAuditableEntity
    {
        //Updated By User
        string UpdatedBy { get; set; }

        //Updated Date
        DateTime UpdatedDate { get; set; }

        //Created By User
        string CreatedBy { get; set; }

        //Created Date
        DateTime CreatedDate { get; set; }


    }
}
