using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev_front.Models
{

   

    public class Book
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("safetyStock")]
        public float SafetyStock { get; set; }

        [JsonProperty("publishingHouse")]
        public PublishingHouse PublishingHouse { get; set; }

        [JsonProperty("promotion")]
        public object Promotion { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; } = new List<Category>();

        [JsonProperty("author")]
        public Author Author { get; set; }


        public int authorId { get; set; }

        public int categoryId { get; set; }

        public List<int> categorieIds { get; set; } = new List<int>();




        public int publishingHouseId { get; set; }

        public int categoryIds { get; set; }

    }


}