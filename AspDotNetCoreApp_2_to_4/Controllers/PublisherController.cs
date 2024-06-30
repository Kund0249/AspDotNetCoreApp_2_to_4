using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreApp_2_to_4.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index","Author");
        }
    }
}
