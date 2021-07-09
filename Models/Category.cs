using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pidev_front.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}