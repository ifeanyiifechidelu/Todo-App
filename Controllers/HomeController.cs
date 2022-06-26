using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Webform.Models;
using Webform.Services;

namespace Webform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _databaseVariable;

        public HomeController(ILogger<HomeController> logger, IService databaseVariable)
        {
            _logger = logger;
            _databaseVariable = databaseVariable;
        }

        public IActionResult Index()
        {
            var tasks =  _databaseVariable.ViewAllData();
            return View(tasks);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(FormModel obj)
        {
            _databaseVariable.CreateTask(obj);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _databaseVariable.DeleteRecordById(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var editView = _databaseVariable.GetTaskById(id);
            return View(editView);
        }
        public IActionResult Update(FormModel obj)
        {
            _databaseVariable.UpdateRecord(obj);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult RemoveAll()
        {
            _databaseVariable.DeleteAllRecord();
            return RedirectToAction("Index");
        }
    }
}
