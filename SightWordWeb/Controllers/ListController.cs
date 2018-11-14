using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SightWordWeb.Infrastructure;
using SightWordWeb.Models;
using SightWordWeb.ViewModels.List;

namespace SightWordWeb.Controllers
{
    public class ListController : Controller
    {
        private readonly IWordListReader _reader;
        private readonly IWordListWriter _writer;

        public ListController()
        {
            //TODO: Remove this constructor after adding dependency injection.
            this._reader = new FileWordListReader();
            this._writer = new FileWordListWriter();
        }

        //public ListController(IWordListReader reader, IWordListWriter writer)
        //{
        //    //TODO:  Use this constructor after adding dependecy injection
        //    this._reader = reader;
        //    this._writer = writer;
        //}


        // GET: List
        public ActionResult Index()
        {
            var model = new ListIndexViewModel();
            var fileList = Directory.EnumerateFiles(".", "*.lst", SearchOption.TopDirectoryOnly);
            foreach (var file in fileList)
            {
                model.WordLists.Add(_reader.Read(file));
            }

            return View(model);
        }

        // GET: List/Details/5
        public ActionResult Details(string id)
        {
            var model = new DetailsWordListViewModel() {
                WordList = _reader.Read($"./{id}.lst")
            };

            return View(model);
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
                var newList = new WordList();
                newList.Name = model.Name;
                var words = model.CommaSeparatedList
                    .Replace(" ", string.Empty)
                    .Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    newList.Add(new Word()
                    {
                        Value = word
                    });
                }
                _writer.Save(newList);

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
        public ActionResult Delete(string id)
        {
            var model = new DeleteWordListViewModel() {
                WordList = _reader.Read($"./{id}.lst")
            };

            return View(model);
        }

        // POST: List/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                System.IO.File.Delete($"./{id}.lst");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}