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
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        public long? CountryOfBirthId { get; set; }
        public long? NationalityId { get; set; }
        public long? MaritalStatusId { get; set; }

        public long? ApplicationNo { get; set; }

        public long? CanShare { get; set; }

    }
}
