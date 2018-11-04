using Newtonsoft.Json;
using System;
using FluentValidation.Validators;
using FluentValidation;

namespace Student.Data
{
    public class StudentIdentityViewModel

    { 
        [JsonProperty(PropertyName = "IdentityID")]
        public long IdentityId { get; set; }

        [JsonProperty(PropertyName = "StudentID")]
        public long? StudentId { get; set; }

        [JsonProperty(PropertyName = "IdentityTypeID")]
        public long? IdentityTypeId { get; set; }

        [JsonProperty(PropertyName = "IdentityNumbers")]
        public string IdentityNumber { get; set; }

        [JsonProperty(PropertyName = "IssueDate")]
        public DateTime? IdentityIssueDate { get; set; }

        [JsonProperty(PropertyName = "ExpiryDate")]
        public DateTime? IdentityExpiryDate { get; set; }

        [JsonProperty(PropertyName = "IssuingAuthority")]
        public string IssuingAuthority { get; set; }

        [JsonProperty(PropertyName = "CanShareIdentity")]
        public long? CanShare { get; set; }

        [JsonProperty(PropertyName = "IsActive")]
        public long? IsActive { get; set; }

    }

    public class StudentIdentityModel
    {
        public long IdentityId { get; set; }

        public long? StudentId { get; set; }

        public long? IdentityTypeId { get; set; }

        public string IdentityNumber { get; set; }

        public DateTime? IdentityIssueDate { get; set; }

        public DateTime? IdentityExpiryDate { get; set; }

        public string IssuingAuthority { get; set; }

        public long? CanShare { get; set; }

        public long? IsActive { get; set; }

    }

    public class StudentIdentityModelValidator :  AbstractValidator<StudentIdentityModel>
    {
        public StudentIdentityModelValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.IdentityTypeId).NotNull();
            RuleFor(x => x.IdentityNumber).NotNull();
            RuleFor(x => x.IdentityIssueDate).NotNull();
            RuleFor(x => x.IdentityExpiryDate).NotNull();
            RuleFor(x => x.IssuingAuthority).NotNull();
            RuleFor(x => x.CanShare).NotNull();
        }

    }

}
