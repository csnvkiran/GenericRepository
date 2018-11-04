using System;
using GR.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Repository
{
    public class StudentContact : Entity
    {
        [Key()]
        public long ContactId { get; set; }

        public long? StudentId { get; set; }

        public long? ContactTypeId { get; set; }
        public string ContactNo { get; set; }
        public long? Priority { get; set; }
        public long? CanShare { get; set; }
        public long? isActive { get; set; }




    }
}
