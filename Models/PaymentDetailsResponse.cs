using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Pidev_front.Models
{
    public class Response
    {
        [JsonProperty("finSessionId")]
        public String FinSessionId { get; set; }

        [JsonProperty("finUrl")]
        public String FinUrl { get; set; }
    }
}