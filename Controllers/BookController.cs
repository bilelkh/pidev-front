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
    public class BookController : Controller
    {

        HttpClient httpClient;
        List<SelectListItem> list = new List<SelectListItem>();

    public BookController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8080/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Book
        public ActionResult Index()
        {

            //For first dropdown:

          



            var response = httpClient.GetAsync("get-all-books").Result;
        
            if (response.IsSuccessStatusCode)
            {
                var books = response.Content.ReadAsAsync<IList<Book>>().Result;
                return View(books);
            }
            else
            {
                return View(new List<Book>());
            }   
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {

            List<SelectListItem> authorOptionList = new List<SelectListItem>();
            List<SelectListItem> publishingHousesOptionList = new List<SelectListItem>();
            List<SelectListItem> categoriesOptionList = new List<SelectListItem>();






            var response = httpClient.GetAsync("get_allAuthors").Result;

            if (response.IsSuccessStatusCode)
            {
                var authors = response.Content.ReadAsAsync<IList<Author>>().Result;

                foreach (var element in authors)
                {
                    authorOptionList.Add(new SelectListItem
                    {
                        Text = element.FirstName + element.LastName,
                        Value = element.Id.ToString()
                    });
                }

            }

            var response2 = httpClient.GetAsync("get-all-PublishingHouses").Result;

            if (response2.IsSuccessStatusCode)
            {
                var publishingHouses = response2.Content.ReadAsAsync<IList<PublishingHouse>>().Result;

                foreach (var element in publishingHouses)
                {
                    publishingHousesOptionList.Add(new SelectListItem
                    {
                        Text = element.Name,
                        Value = element.Id.ToString()
                    });
                }
            }

       

          

            var response3 = httpClient.GetAsync("get-all-categories").Result;

            if (response3.IsSuccessStatusCode)
            {
                var categories = response3.Content.ReadAsAsync<IList<Category>>().Result;
                foreach (var element in categories)
                {
                    categoriesOptionList.Add(new SelectListItem
                    {
                        Text = element.Title,
                        Value = element.Id.ToString()
                    });
                }
            }
           

 




            ViewBag.authorOptionList = authorOptionList;
            ViewBag.publishingHousesOptionList = publishingHousesOptionList;
            ViewBag.categoriesOptionList = categoriesOptionList;

            /*  var response = httpClient.GetAsync("get-all-books").Result;

              if (response.IsSuccessStatusCode)
              {
                  var books = response.Content.ReadAsAsync<IList<Book>>().Result;
                  var author = new Author() ;
                //  author.books = books;
                  return View(books);
              }
              else
              {
                  return View(new List<Book>());
              }
            */

            return View();
          
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            
                // TODO: Add insert logic here

                try
                {
                book.categorieIds.Add(book.categoryId); 


                    var response = httpClient.PostAsJsonAsync("add_book", book).ContinueWith(task =>

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

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
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

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
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
