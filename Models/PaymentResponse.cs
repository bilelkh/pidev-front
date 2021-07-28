using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Pidev_front.Models
{
    public class PaymentResponse
    {
        [JsonProperty("status")]
        public String Status { get; set; }
    }
}