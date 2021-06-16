using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using OnlineCricketStore.ViewModels;

namespace OnlineCricketStore.Controllers
{
    public class HomeController : Controller
    {
        readonly HttpClient  client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44356/api/")
        };
        public ActionResult Index()
        {
            var itemList = new List<ProductsVM>();
               

                var response = client.GetAsync("CricketProduct/GetAllProducts");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ProductsVM>>();
                    readTask.Wait();

                    var res = readTask.Result;

                    if (res != null) itemList.AddRange(res);
                }

                ViewBag.Title = "Home Page";

                return View(itemList);
            
        }

        [HttpGet]
        public ActionResult GetProductDataById(int id)
        {
            var data = GetProductById(id);
            
            return View(data);
        }

       
        public JsonResult GetProductById( int id)
        {
            var itemList = new ProductsVM();
            
                var response = client.GetAsync("CricketProduct/GetProductById/" + id);
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProductsVM>();
                    readTask.Wait();

                    itemList = readTask.Result;
                }

                switch (id)
                {
                    case 1:
                        ViewBag.Productname = "SS Vintage 7 Finisher- MS Dhoni Edition";
                        ViewBag.Image = "~/Images/SS-7.jpg";
                        break;
                    case 2:
                        ViewBag.Productname = "MRF-VK Virat Edition";
                    ViewBag.Image = "~/Images/SS-7.jpgF-VK.jpg";
                    break;
                    case 3:
                        ViewBag.Productname = "Spartan - Gayle Edition";
                        ViewBag.Image = "~/Images/Spartan-Gayle-THE-BOSS-Junior-Cricket-Bat-2.jpg";
                    break;
                }

                var getAttr = client.GetAsync("CricketProduct/GetProductAttributes/" + id);
                getAttr.Wait();

                var res1 = getAttr.Result;
                if (res1.IsSuccessStatusCode)
                {
                    var readTask1 = result.Content.ReadAsAsync<List<ProductsVM>>();
                    readTask1.Wait();

                    itemList.Weight = readTask1.Result.Select(e =>e.Weight).ToString();
                    itemList.WillowGrade = readTask1.Result.Select(e => e.WillowGrade).ToString();
                    itemList.GripColor = readTask1.Result.Select(e => e.GripColor).ToString();
            }


            return Json(itemList, JsonRequestBehavior.AllowGet);

        }
    }
}
