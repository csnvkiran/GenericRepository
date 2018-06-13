using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GR.Service
{

    public class ServiceError
    {
        public static readonly ServiceError ServiceNotAvailable = new ServiceError(50001, "ServiceNotAvailable");
        public static readonly ServiceError DataReadServiceError = new ServiceError(50002, "Data Read Service Error");
        public static readonly ServiceError DataUpdateServiceError = new ServiceError(50003, "Data Update Service Error");


        public ServiceError(int code, string error)
        {
            Code = code;
            Error = error;
        }

        public int Code { get; }
        public string Error { get; }
    }

    public class ValidationError
    {
    
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty? field: null;
            Message = message;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        public string Message { get; }

    }



}
