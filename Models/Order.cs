using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pidev_front.Models
{
    public class Order
    {
        [JsonProperty("id")]

        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("addressId")]
        public int AddressId { get; set; }

        [JsonProperty("books")]
        public List<string> Books { get; set; }

        [JsonProperty("coupon")]

        public Coupon Coupon { get; set; }

        [JsonProperty("status")]

        public string Status { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }


    }
}