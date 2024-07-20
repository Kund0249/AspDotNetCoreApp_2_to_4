using Microsoft.AspNetCore.Mvc;
using CoreWebApp_2_4.Models;
using CoreWebApp_2_4.Model;
using CoreWebApp_2_4.DataAccess.Repositories;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using CoreWebApp_2_4.DataAccess.Data;
using System.Reflection;
using CoreWebApp_2_4.DataAccess.Entities;

namespace CoreWebApp_2_4.Controllers
{
    public class PublisherController : BaseController
    {
        //private readonly PublisherRepository _publisherRepository;
        public readonly DataContext _dbcontext;
        public PublisherController(DataContext context)
        {
            //_publisherRepository = new PublisherRepository();
            _dbcontext = context;
        }

        [HttpGet]
        public IActionResult Index(int pageno = 1)
        {
            if (pageno <= 0)
                pageno = 1;

            List<PublisherModel> models = new List<PublisherModel>();
            int TotalItems = _dbcontext.Publishers.Count();
            PaginationModel pagination = new PaginationModel(pageno, TotalItems,5);
            var data = _dbcontext.Publishers.Skip((pagination.CurrentPage - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
            if (data != null)
            {
                if (data.Count > 0)
                {
                    models = data.Select(x => PublisherModel.Convert(x)).ToList();
                }
            }
            ViewBag.Pagenition = pagination;
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
                _dbcontext.Add(PublisherModel.Convert(model));
                _dbcontext.SaveChanges();
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Publisher model = _dbcontext.Publishers.SingleOrDefault(x => x.PublisherId == id);
            if (model == null)
            {
                ShowNotification("Not Found", "Record not found!", NotificationType.error);
                return RedirectToAction(nameof(Index));
            }

            PublisherModel Viewmodel = PublisherModel.Convert(model);
            

            return View(Viewmodel);
        }

        [HttpPost]
        public IActionResult Edit(PublisherModel model)
        {

            if (ModelState.IsValid)
            {
                Publisher _publisher = _dbcontext.Publishers.SingleOrDefault(x => x.PublisherId == model.PublisherId);
                if (_publisher == null)
                {
                    ShowNotification("Not Found", "Record not found!", NotificationType.error);
                    return RedirectToAction(nameof(Index));
                }

                _publisher.PublisherName = model.PublisherName;
                _publisher.EmailAddress = model.EmailAddress;
                _publisher.ContactNo = model.ContactNo;
                _dbcontext.SaveChanges();

                ShowNotification("Data Save", "Record Updated successfully!", NotificationType.success);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ShowNotification("Inavlid Data", "Data is invalid!", NotificationType.error);
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Publisher model = _dbcontext.Publishers.SingleOrDefault(x => x.PublisherId == id);
            if (model == null) {
                ShowNotification("Not Found","Record not found!",NotificationType.error);
              
            }
            else
            {
                _dbcontext.Publishers.Remove(model);
                _dbcontext.SaveChanges();
                ShowNotification("Removed", "Record delete successfully!", NotificationType.success);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
