using Berkan.Engines.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkan.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var operationMessage = (TempData["OperationMessage"] ?? "").ToString();

            if (!string.IsNullOrWhiteSpace(operationMessage))
            {
                ViewBag.OperationMessage = operationMessage;
            }
            return View();
        }


    }
}
