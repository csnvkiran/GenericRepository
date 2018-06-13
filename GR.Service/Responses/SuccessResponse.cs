using System;
using System.Collections.Generic;
using System.Text;
using GR.Service.Interface;
using Newtonsoft.Json;

namespace GR.Service
{
    /// <summary>
    /// response = {
    ///     'status': 200,
    ///     'apiVersion': '1.2',  # helpful to show the formal minor version to the client
    ///     'hostname': os.environ.get('HTTP_HOST'),
    ///     'path': os.environ.get('PATH_INFO'),
    ///     'instanceId': os.environ.get('INSTANCE_ID'),
    ///     'codeVersion': os.environ.get('CURRENT_VERSION_ID'),
    ///     'requestId': os.environ.get('REQUEST_LOG_ID'),
    ///     'data': {
    ///         # your actual API response goes here
    ///     }
    ///     "error" : {
    ///     "code" : "e3526",
    ///     "message" : "Missing UserID",
    ///     "description" : "A UserID is required to edit a user.",
    ///     "link" : "http://docs.mysite.com/errors/e3526/"
    ///     }
    /// }
    /// 
    /// </summary>
    /// Entity<TId> : IEntity<TId> where TId : IEquatable<TId>
    public class SuccessResponse : IResponse 
    {

        public SuccessResponse(string requestId)
        {
            RequestId = requestId;
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

        public bool Success { get; set; }

    }
}

