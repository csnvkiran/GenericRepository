using System;
using GR.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Repository
{
    public class StudentAddress : Entity
    {
        [Key()]
        public long AddressId { get; set; }

        public long? StudentId { get; set; }

        public long? AddressTypeId { get; set; }

        public string POBox { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public long? Country { get; set; }

        public long? State { get; set; }

        public long? City { get; set; }

        public long? CanShare { get; set; }

        public long? IsActive { get; set; }

    }
}
