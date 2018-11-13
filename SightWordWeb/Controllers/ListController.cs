using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SightWordWeb.ViewModels.List;

namespace SightWordWeb.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            var model = new ListIndexViewModel();
            model.WordLists.Add()


            return View(model);
        }

        // GET: List/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: List/Create
        public ActionResult Create()
        {
            var model = new CreateWordListViewModel();
            return View(model);
        }

        // POST: List/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateWordListViewModel model)
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

        // GET: List/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: List/Edit/5
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

        // GET: List/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: List/Delete/5
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