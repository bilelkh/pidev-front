using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Pidev_front.Models;

namespace Pidev_front.Controllers
{
    public class PromotionController : Controller
    {
        HttpClient httpClient;
        List<SelectListItem> list = new List<SelectListItem>();


        public PromotionController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public ActionResult Index()
        {
            var response = httpClient.GetAsync("get-all-Promotions").Result;

            if (response.IsSuccessStatusCode)
            {
                var promotions = response.Content.ReadAsAsync<IList<Promotion>>().Result;
                return View(promotions);
            }
            else
            {
                return View(new List<Promotion>());
            }
        }

        // GET: Promotion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Promotion/Create
        public ActionResult Create()
        {
            List<SelectListItem> bookOptionList = new List<SelectListItem>();

            var response = httpClient.GetAsync("get-all-books").Result;

            if (response.IsSuccessStatusCode)
            {
                var books = response.Content.ReadAsAsync<IList<Book>>().Result;

                foreach (var element in books)
                {
                    bookOptionList.Add(new SelectListItem
                    {
                        Text = element.Title,
                        Value = element.Id.ToString()
                    });
                }

            }


            ViewBag.bookOptionList = bookOptionList;




            return View();
        }

        // POST: Promotion/Create
        [HttpPost]
        public ActionResult Create(Promotion promotion)
        {
            try
            {

                promotion.booksIds.Add(promotion.bookId);
                var response = httpClient.PostAsJsonAsync("add-Promotion", promotion).ContinueWith(task =>

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

        // GET: Promotion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Promotion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Promotion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Promotion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
