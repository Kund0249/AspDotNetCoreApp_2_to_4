using Microsoft.AspNetCore.Mvc;
using CoreWebApp_2_4.Models;
using CoreWebApp_2_4.DataAccess.Repositories;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CoreWebApp_2_4.Controllers
{
    public class PublisherController : BaseController
    {
        private readonly PublisherRepository _publisherRepository;
        public PublisherController()
        {
            _publisherRepository = new PublisherRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
           List<PublisherModel> models = new List<PublisherModel>();
            
            var data = _publisherRepository.Publishers;
            if(data != null)
            {
                if(data.Count > 0)
                {
                    models = data.Select(x => PublisherModel.Convert(x)).ToList();
                }
            }

            //if(TempData["Message"] != null)
            //{
            //    ViewBag.Message = TempData["Message"];
            //}

            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(string PublisherName,string EmailAddress,string ContactN)
        //{
        //    return View();
        //}
         
        [HttpPost]
        public IActionResult Create(PublisherModel model)
        {
            if (ModelState.IsValid)
            {
                _publisherRepository.Save(PublisherModel.Convert(model));
                ShowNotification("Data Save", "Record save successfully!", NotificationType.success);

                //var notificationMessage = new
                //{
                //    Title = "Success",
                //    Message = "Record Save Successfully!",
                //    MessageType = "info"
                //};
                ////TempData["Message"] = JsonSerializer.Serialize("Record Save Successfully!");
                //TempData["Message"] = JsonSerializer.Serialize(notificationMessage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //ViewBag.Message = "Please enter valid values";
                //ViewData["Message"] = "Please enter valid values";
                ShowNotification("Inavlid Data", "Data is invalid!", NotificationType.error);

                ViewBag.Message = new string[]
                {
                    "Name should not be more than 50 char.",
                    "Email address must be valid email address",
                    "Contact number should not exceed 10 digit"
                };

                ViewData["Message"] = new string[]
                {
                    "Name should not be more than 50 char.",
                    "Email address must be valid email address",
                    "Contact number should not exceed 10 digit"
                };
                return View(model);
            }
        }
    }
}
