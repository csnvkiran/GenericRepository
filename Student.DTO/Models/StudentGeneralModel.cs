using Newtonsoft.Json;
using System;
using FluentValidation.Validators;
using FluentValidation;

namespace Student.Data
{
    public class StudentGeneralViewModel

    { 
        [JsonProperty(PropertyName = "Student ID")]
        public decimal StudentId { get; set; }

        [JsonProperty(PropertyName = "Student Name")]
        public string StudentName { get; set; }

        [JsonProperty(PropertyName = "Student Gender")]
        public decimal? GenderId { get; set; }

       // public Gender Gender

    }

    public class StudentGeneralModel
    {


        public decimal? StudentId { get; set; }

        //[JsonRequired]
        public string StudentName { get; set; }

        public decimal? GenderId { get; set; }

        // public Gender Gender

    }

    public class StudentGeneralModelValidator :  AbstractValidator<StudentGeneralModel>
    {
        public StudentGeneralModelValidator()
        {
            RuleFor(x => x.StudentName).NotEmpty();
            RuleFor(x => x.GenderId).NotNull();

        }

    }

}
