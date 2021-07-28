using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace Pidev_front.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("addressId")]
        public string AddressId { get; set; }

        [JsonProperty("books")]
        public ISet<Book> Books { get; set; }

        [JsonProperty("coupon")]
        public int Coupon { get; set; }

        [JsonProperty("status")]
        public OrderStatus Status { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

    }

    public enum OrderStatus
    {
        [Display(Name = "NEW")]
        NEW,
        [Display(Name = "PROCESSING")]
        PROCESSING,
        [Display(Name = "SHIPPING")]
        SHIPPING,
        [Display(Name = "DELIVERED")]
        DELIVERED,
        [Display(Name = "CANCELED")]
        CANCELED
    }

    public class OrderStats
    {
        [JsonProperty("countNew")]
        public int? CountNew { get; set; }

        [JsonProperty("countDelivered")]
        public int? CountDelivered { get; set; }

        [JsonProperty("countShipping")]
        public int? CountShipping { get; set; }
        
        [JsonProperty("countCanceled")]
        public int? countCanceled { get; set; }
       
        [JsonProperty("countProcessing")]
        public int? countProcessing { get; set; }
        [JsonProperty("countOrders")]
        public int? countOrders { get; set; }

        [JsonProperty("countCouponIsApplied")]
        public int? countCouponIsApplied { get; set; }
    }

}