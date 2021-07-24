using Pidev_front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Pidev_front.Controllers
{
    public class OrderController : Controller
    {
        HttpClient httpClient;

        public OrderController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/order/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Order
        public ActionResult Index()
        {
            var response = httpClient.GetAsync("all").Result;
            if (response.IsSuccessStatusCode)
            {
                var orders = response.Content.ReadAsAsync<IList<Order>>().Result;
                return View(orders);
            }
            else
            {
                return View(new List<Order>());
            }
        }
    }
}
