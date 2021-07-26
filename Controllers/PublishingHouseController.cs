using Pidev_front.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace Pidev_front.Controllers
{
    public class PublishingHouseController : Controller



    {
        HttpClient httpClient;


        public PublishingHouseController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: PublishingHouse
        public ActionResult Index()
        {
            var response = httpClient.GetAsync("get-all-PublishingHouses").Result;

            if (response.IsSuccessStatusCode)
            {
                var publishingHouses = response.Content.ReadAsAsync<IList<PublishingHouse>>().Result;
                return View(publishingHouses);
            }
            else
            {
                return View(new List<PublishingHouse>());
            }
        }

        // GET: PublishingHouse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublishingHouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublishingHouse/Create
        [HttpPost]
        public ActionResult Create(PublishingHouse publishingHouse)
        {
            try
            {
                publishingHouse.Id = null;
                var response = httpClient.PostAsJsonAsync("add-PublishingHouse", publishingHouse).ContinueWith(task =>

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

        // GET: PublishingHouse/Edit/5
        public ActionResult Edit(int id)
        {
            var response = httpClient.GetAsync("get-PublishingHouses-by-id/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var publishingHouse = response.Content.ReadAsAsync<PublishingHouse>().Result;
                return View(publishingHouse);
            }
            else
            {
                return View(new Category());
            }
        }

        // POST: PublishingHouse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PublishingHouse publishingHouse)
        {
            try
            {

                var response = httpClient.PutAsJsonAsync("update-PublishingHouse/" + id.ToString(), publishingHouse).ContinueWith(task =>
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

        // GET: PublishingHouse/Delete/5
        public ActionResult Delete(int id)
        {
            var response = httpClient.GetAsync("get-PublishingHouses-by-id/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var publishingHouses = response.Content.ReadAsAsync<PublishingHouse>().Result;
                return View(publishingHouses);
            }
            else
            {
                return View(new PublishingHouse());
            }
        }

        // POST: PublishingHouse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PublishingHouse publishingHouse)
        {
            try
            {
                var response = httpClient.DeleteAsync("remove-PublishingHouse/" + id.ToString()).ContinueWith(task =>
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
