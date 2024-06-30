using AspDotNetCoreApp_2_to_4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreApp_2_to_4.Controllers
{
    public class AuthorController : Controller
    {

        [HttpGet]
        public ViewResult Index()
        {
            //Code to Get Data;
            List<AuthorModel> authors = new List<AuthorModel>();
            authors.Add(new AuthorModel()
            {
                AuthorId = 1,
                AuthorName = "John",
                EmailAddress = "john@gmail.com",
                Mobile = "6754342345"
            });
            authors.Add(new AuthorModel()
            {
                AuthorId = 1,
                AuthorName = "Sam",
                EmailAddress = "sam@gmail.com",
                Mobile = "6754342345"
            });

            return View(authors);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Create(AuthorModel model)
        {
            //Save the data
            return View();
        }

    }
}
