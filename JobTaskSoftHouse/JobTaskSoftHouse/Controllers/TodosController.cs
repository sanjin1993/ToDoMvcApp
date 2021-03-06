﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JobTaskSoftHouse.Models;
using JobTaskSoftHouse.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JobTaskSoftHouse.Controllers
{
    public class TodosController : Controller
    {

        WebAPIHelper todosService = new WebAPIHelper("https://jsonplaceholder.typicode.com/todos", "todos");
        // GET: Todos

        List<Todo> todos = new List<Todo>();

        public ActionResult Index()
        {
            return View();
        }

        public List<Todo> GetAll()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                todos = JsonConvert.DeserializeObject<List<Todo>>(json);
            }

            return todos;
        }

        // GET: Todos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Todos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Todos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Todos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Todos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Todos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}