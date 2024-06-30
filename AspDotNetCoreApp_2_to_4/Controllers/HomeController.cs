using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreApp_2_to_4.Controllers
{
    public class HomeController : Controller
    {
        //End point
        public string Index()
        {
            return "Hello from Index of Home Controller.";
        }
    }
}
