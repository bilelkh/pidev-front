using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Pidev_front.Models
{
    public class Session
    {

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("bookList")]
        public List<Book> BookList { get; set; }

        [JsonProperty("url")]
        public String Url { get; set; }

        [JsonProperty("totalPrice")]
        public Double TotalPrice { get; set; }

        [JsonProperty("codeCoupon")]
        public String CodeCoupon { get; set; }

        [JsonProperty("couponIsApplied")]
        public Boolean CouponIsApplied { get; set; }

    }
}