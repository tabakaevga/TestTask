using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly XmlParser _parser = new XmlParser();

        public IActionResult Index()
        {
            return View(_parser.TagNameValuePairs);
        }

        [HttpPost]
        public string Submission()
        {
            var dataFromForm = Request.Form;
            var writer = new XmlWriter();
            writer.WriteToXml(dataFromForm);
            return "Edited Successfully";
        }
    }
}
