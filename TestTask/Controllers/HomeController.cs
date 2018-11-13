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
        /// <summary>
        /// Отображение данных на html странице
        /// </summary>
        public IActionResult Index()
        {
            return View(new  XmlParser().TagNameValuePairs);
        }

        /// <summary>
        /// Обработка метода Post при нажатии на кнопку Submit в форме
        /// </summary>
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
