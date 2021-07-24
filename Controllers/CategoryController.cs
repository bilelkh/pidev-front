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
    public class CategoryController : Controller
    {
        HttpClient httpClient;

        public CategoryController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Category
        public ActionResult Index()
        {
            var response = httpClient.GetAsync("get-all-categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var categories = response.Content.ReadAsAsync<IList<Category>>().Result;
                return View(categories);
            }
            else
            {
                return View(new List<Category>());
            }
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                category.Id = null ; 
 
                var response = httpClient.PostAsJsonAsync("add-category", category).ContinueWith(task =>
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {


            var response = httpClient.GetAsync("category-by-id/"+id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var categories = response.Content.ReadAsAsync<Category>().Result;
                return View(categories);
            }
            else
            {
                return View(new Category());
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            try
            {

                var response = httpClient.PutAsJsonAsync("update-category/"+id.ToString(), category).ContinueWith(task =>
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {

            var response = httpClient.GetAsync("category-by-id/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var categories = response.Content.ReadAsAsync<Category>().Result;
                return View(categories);
            }
            else
            {
                return View(new Category());
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Category category)
        {
            try
            {

                var response = httpClient.DeleteAsync("remove-category/" + id.ToString()).ContinueWith(task =>
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
