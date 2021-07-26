using Pidev_front.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
namespace Pidev_front.Controllers
{
    public class AuthorController : Controller
    {
        HttpClient httpClient;

        public AuthorController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Author
        public ActionResult Index()
        {
            var response = httpClient.GetAsync("get_allAuthors").Result;

            if (response.IsSuccessStatusCode)
            {
                var authors = response.Content.ReadAsAsync<IList<Author>>().Result;
                return View(authors);
            }
            else
            {
                return View(new List<Author>());
            }
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                author.Id = null;
                var response = httpClient.PostAsJsonAsync("add_Author", author).ContinueWith(task =>

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

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            var response = httpClient.GetAsync("author/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var author = response.Content.ReadAsAsync<Author>().Result;
                return View(author);
            }
            else
            {
                return View(new Author());
            }
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                var response = httpClient.PutAsJsonAsync("update-Author/" + id.ToString(), author).ContinueWith(task =>
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

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            var response = httpClient.GetAsync("author/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var author = response.Content.ReadAsAsync<Author>().Result;
                return View(author);
            }
            else
            {
                return View(new Author());
            }
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                var response = httpClient.DeleteAsync("remove-Author/" + id.ToString()).ContinueWith(task =>
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
