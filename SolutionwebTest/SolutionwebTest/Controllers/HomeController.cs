using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolutionwebTest.Models;

namespace SolutionwebTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly FormInfoContext _db;

        public HomeController(FormInfoContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Save to database";
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormInfo info)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.formInfos.Add(info);
            _db.SaveChanges();          
            return RedirectToAction("Update", "Home", new {id = info.Id });
        }

       
        public IActionResult Update(long id)
        {
            ViewData["Message"] = "Update database";
            FormInfo info = _db.formInfos.Find(id);
            return View(info);
        }

        [HttpPost]
        public IActionResult Update(FormInfo info)
        {
            _db.formInfos.Update(info);
            _db.SaveChanges();
            return RedirectToAction("Delete");
        }

        public IActionResult Delete()
        {
            ViewData["Message"] = "Delete table rows";
            var forminfos = _db.formInfos.ToArray();
            return View(forminfos);
        }

        [HttpPost]
        public IActionResult Delete(long? id)
        {
            var forminfos = _db.formInfos.ToArray();
            Debug.WriteLine("inside delete trying to delete reccord with id: " + id);
            if (id == null)
            {
                return View(forminfos);
            }
            FormInfo existing = _db.formInfos.Find(id);
            if (!(existing == null)) { 
            _db.formInfos.Remove(existing);
            _db.SaveChanges();
            ViewData["Message"] = "Delete table rows";
            return View(forminfos);
            } 
            ViewData["Message"] = "No row for id " + id;
            return View();
            
        
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Åsa Wegelius.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
