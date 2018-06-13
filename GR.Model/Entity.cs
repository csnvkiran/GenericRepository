//
using System;
using System.Collections.Generic;
using System.Text;
using GR.Model.Interface;
using System.ComponentModel.DataAnnotations;

namespace GR.Model
{

    /// <summary>
    /// Entity with Auditable Fields
    /// Ex: Table in Database
    /// </summary>
    public abstract class Entity :  IEntity, IAuditableEntity
    {

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedDate { get; set; }

    }
}
