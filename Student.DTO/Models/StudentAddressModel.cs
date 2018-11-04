using Newtonsoft.Json;
using System;
using FluentValidation.Validators;
using FluentValidation;

namespace Student.Data
{
    public class StudentAddressViewModel

    { 
        [JsonProperty(PropertyName = "AddressID")]
        public long AddressId { get; set; }

        [JsonProperty(PropertyName = "StudentID")]
        public long? StudentId { get; set; }

        [JsonProperty(PropertyName = "AddressTypeID")]
        public long? AddressTypeId { get; set; }

        [JsonProperty(PropertyName = "POBox")]
        public string POBox { get; set; }

        [JsonProperty(PropertyName = "AddressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty(PropertyName = "AddressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty(PropertyName = "Country")]
        public long? CountryId { get; set; }

        [JsonProperty(PropertyName = "State")]
        public long? StateId { get; set; }

        [JsonProperty(PropertyName = "City")]
        public long? City { get; set; }

        [JsonProperty(PropertyName = "CanShareAddress")]
        public long? CanShare { get; set; }

        [JsonProperty(PropertyName = "IsActive")]
        public long? IsActive { get; set; }

    }

    public class StudentAddressModel
    {
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

    public class StudentAddressModelValidator :  AbstractValidator<StudentAddressModel>
    {
        public StudentAddressModelValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.AddressTypeId).NotNull();
            RuleFor(x => x.POBox).NotNull();
            RuleFor(x => x.AddressLine1).NotNull();
            RuleFor(x => x.Country).NotNull();
            RuleFor(x => x.State).NotNull();
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.CanShare).NotNull();
        }

    }

}
