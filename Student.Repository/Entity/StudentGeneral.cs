using System;
using GR.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Repository
{
    public class StudentGeneral : Entity
    {
        [Key()]
        public long StudentId { get; set; }

        public string StudentName { get; set; }

        //[NotMapped]
        public long? GenderId { get; set; }


    }
}
