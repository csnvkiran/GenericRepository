using Newtonsoft.Json;
using System;
using FluentValidation.Validators;
using FluentValidation;

namespace Student.Data
{
    public class StudentGeneralViewModel

    { 
        [JsonProperty(PropertyName = "StudentID")]
        public decimal StudentId { get; set; }

        [JsonProperty(PropertyName = "StudentName")]
        public string StudentName { get; set; }

        [JsonProperty(PropertyName = "StudentGender")]
        public decimal? GenderId { get; set; }

        [JsonProperty(PropertyName = "DateofBirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "PlaceofBirth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty(PropertyName = "CountryofBirth")]
        public decimal? CountryOfBirthId { get; set; }

        [JsonProperty(PropertyName = "Nationality")]
        public decimal? NationalityId { get; set; }

        [JsonProperty(PropertyName = "MaritalStatus")]
        public decimal? MaritalStatusId { get; set; }

        [JsonProperty(PropertyName = "ApplicationNo")]
        public decimal? ApplicationNo { get; set; }

        [JsonProperty(PropertyName = "Can Share student Profile")]
        public decimal? CanShare { get; set; }

    }

    public class StudentGeneralModel
    {


        public decimal? StudentId { get; set; }

        public string StudentName { get; set; }

        public decimal? GenderId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public decimal? CountryOfBirthId { get; set; }

        public decimal? NationalityId { get; set; }

        public decimal? MaritalStatusId { get; set; }

        public decimal? ApplicationNo { get; set; }

        public decimal? CanShare { get; set; }
        // public Gender Gender

    }

    public class StudentGeneralModelValidator :  AbstractValidator<StudentGeneralModel>
    {
        public StudentGeneralModelValidator()
        {
            RuleFor(x => x.StudentName).NotEmpty();
            RuleFor(x => x.GenderId).NotNull();
            RuleFor(x => x.DateOfBirth).NotNull();
            RuleFor(x => x.PlaceOfBirth).NotNull();
            RuleFor(x => x.CountryOfBirthId).NotNull();
            RuleFor(x => x.NationalityId).NotNull();
            RuleFor(x => x.MaritalStatusId).NotNull();
            RuleFor(x => x.CanShare).NotNull();

        }

    }

}
