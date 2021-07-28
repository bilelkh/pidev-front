using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pidev_front.Models
{
    public class Promotion
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string title { get; set; }
        public string endDate { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public object value { get; set; }
        public List<object> books { get; set; }

        public int bookId { get; set; }


        public List<int> booksIds { get; set; } = new List<int>();

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 



}