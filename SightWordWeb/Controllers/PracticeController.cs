using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SightWordWeb.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        // GET: Reviewer
        public ActionResult Reviewer()
        {
            return View();
        }
     
    }
}