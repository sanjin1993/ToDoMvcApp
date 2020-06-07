using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobTaskSoftHouse.Models;
using System.Net.Http;
using JobTaskSoftHouse.Util;
using Newtonsoft.Json;
using System.IO;

namespace JobTaskSoftHouse.Controllers
{
    public class HomeController : Controller
    {

        WebAPIHelper todosService = new WebAPIHelper("https://jsonplaceholder.typicode.com/todos", "todos");

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FeedFile()
        {
            HttpResponseMessage response = todosService.GetResponse();
            string json;

            if (response.IsSuccessStatusCode && new FileInfo("file.json").Length == 0)
            {
                json = JsonConvert.SerializeObject(response.Content.ReadAsAsync<List<Todo>>().Result);
                System.IO.File.WriteAllText("file.json", json);
            }

            return RedirectToAction("Index", "Todos");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();    
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
