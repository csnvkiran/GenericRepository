using System;
using GR.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Repository
{
    public class StudentIdentity : Entity
    {
        [Key()]
        public long IdentityId { get; set; }

        public long? StudentId { get; set; }

        public long? IdentityTypeId { get; set; }

        //[NotMapped]
        public string IdentityNumber { get; set; }
        public DateTime? IdentityIssueDate { get; set; }
        public DateTime? IdentityExpiryDate { get; set; }

        public string IssuingAuthority { get; set; }

        public long? CanShare { get; set; }
        public long? IsActive { get; set; }


    }
}
