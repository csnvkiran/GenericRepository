﻿using GR.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GR.Service
{
    public class ValidationErrorsReponse :IResponse
    {

        public ValidationErrorsReponse(string requestId, string message, ICollection<ValidationError> errors)
        {
            RequestId = requestId;
            Message = message;
            ValidationErrors = errors;
        }

        [JsonProperty(PropertyName = "Service ID")]
        public string ServiceId { get; set; }

        [JsonProperty(PropertyName = "Request ID")]
        public String RequestId { get; set; }

        [JsonProperty(PropertyName = "Transaction ID")]
        public string TrasactionId { get; set; }

        [JsonProperty(PropertyName = "Transaction Date")]
        public DateTime TrasactionDate { get; set; }

        [JsonProperty(PropertyName = "API Version")]
        public string ApiVersion { get; set; }

        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "Validation Errors")]
        public IEnumerable<ValidationError> ValidationErrors { get; set; }




    }
}
