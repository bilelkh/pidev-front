using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidev_front.Models
{
    public class Coupon
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("couponCode")]
        public string CouponCode { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("discount")]
        public int Discount { get; set; }

        [JsonProperty("isPercentage")]
        public Boolean IsPercentage { get; set; }

        [JsonProperty("active")]
        public Boolean Active { get; set; }

        [JsonProperty("type")]
        public CouponType Type { get; set; }

        [JsonProperty("appliedWithPromo")]
        public Boolean AppliedWithPromo { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }

    public enum CouponType
    {
        [Display(Name = "Global")]
        Global,
        [Display(Name = "Unique")]
        Unique,
        [Display(Name = "UPU")]
        UniquePerUser
    }

}