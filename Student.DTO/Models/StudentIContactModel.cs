using Newtonsoft.Json;
using System;
using FluentValidation.Validators;
using FluentValidation;

namespace Student.Data
{
    public class StudentContactViewModel

    {
        [JsonProperty(PropertyName = "ContactID")]
        public long ContactId { get; set; }

        [JsonProperty(PropertyName = "StudentID")]
        public long? StudentId { get; set; }

        [JsonProperty(PropertyName = "ContactTypeID")]
        public long? ContactTypeId { get; set; }

        [JsonProperty(PropertyName = "ContactNumber")]
        public string ContactNo { get; set; }

        [JsonProperty(PropertyName = "PriorityID")]
        public long? Priority { get; set; }

        [JsonProperty(PropertyName = "CanShareIdentity")]
        public long? CanShare { get; set; }

        [JsonProperty(PropertyName = "Is Active")]
        public long? IsActive { get; set; }

    }

    public class StudentContactModel
    {
        public long ContactId { get; set; }

        public long? StudentId { get; set; }

        public long? ContactTypeId { get; set; }

        public string ContactNo { get; set; }

        public long? Priority { get; set; }

        public long? CanShare { get; set; }

        public long? isActive { get; set; }

    }

    public class StudentContactModelValidator : AbstractValidator<StudentContactModel>
    {
        public StudentContactModelValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.ContactTypeId).NotNull();
            RuleFor(x => x.ContactNo).NotNull();
            RuleFor(x => x.Priority).NotNull();
            RuleFor(x => x.CanShare).NotNull();
        }

    }

}
