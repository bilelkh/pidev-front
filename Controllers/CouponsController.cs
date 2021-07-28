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
    public class CouponsController : Controller
    {
        HttpClient httpClient;

        public CouponsController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/coupon/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Coupon
        public ActionResult Index()
        {
            List<SelectListItem> userOptionList = new List<SelectListItem>();
            List<SelectListItem> couponOptionList = new List<SelectListItem>();

            var response = httpClient.GetAsync("/user/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<IList<User>>().Result;
                foreach (var c in users)
                {
                    userOptionList.Add(new SelectListItem
                    {
                        Text = c.FirstName,
                        Value = c.Id.ToString()
                    });
                }
            }

            response = httpClient.GetAsync("all").Result;
            if (response.IsSuccessStatusCode)
            {
                var categories = response.Content.ReadAsAsync<IList<Coupon>>().Result;
                foreach (var c in categories)
                {
                    couponOptionList.Add(new SelectListItem
                    {
                        Text = c.CouponCode,
                        Value = c.CouponCode
                    });
                }
                ViewBag.userOptionList = userOptionList;
                ViewBag.couponOptionList = couponOptionList;
                return View(categories);
            }

            return View();
        }

        // GET: Coupon/Details/5
        public ActionResult Details(string CouponCode)
        {
            if (CouponCode is null)
            {
                throw new ArgumentNullException(nameof(CouponCode));
            }

            var response = httpClient.GetAsync("?coupon=" + CouponCode).Result;
            if (response.IsSuccessStatusCode)
            {
                var coupon = response.Content.ReadAsAsync<Coupon>().Result;
                return View(coupon);
            }
            else
            {
                return View(new Coupon());
            }
        }

        // GET: Coupon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        [HttpPost]
        public ActionResult Create(Coupon coupon)
        {
            try
            {
                coupon.Id = null;

                var response = httpClient.PostAsJsonAsync("", coupon).ContinueWith(task =>
                {
                    if (task.Result.IsSuccessStatusCode)
                    {
                        var result = task.Result.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        task.Result.EnsureSuccessStatusCode();
                    }
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Coupon/Edit/5
        public ActionResult Edit(string CouponCode)
        {
            if (CouponCode is null)
            {
                throw new ArgumentNullException(nameof(CouponCode));
            }

            var response = httpClient.GetAsync("?coupon=" + CouponCode).Result;
            if (response.IsSuccessStatusCode)
            {
                var categories = response.Content.ReadAsAsync<Coupon>().Result;
                return View(categories);
            }
            else
            {
                return View(new Coupon());
            }
        }

        // POST: Coupon/Edit/5
        [HttpPost]
        public ActionResult Edit(Coupon coupon)
        {
            try
            {

                var response = httpClient.PutAsJsonAsync("", coupon).ContinueWith(task =>
                {
                    if (task.Result.IsSuccessStatusCode)
                    {
                        var result = task.Result.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        task.Result.EnsureSuccessStatusCode();
                    }
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
