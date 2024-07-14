using Microsoft.AspNetCore.Mvc;
using CoreWebApp_2_4.Models;
using CoreWebApp_2_4.Model;
using CoreWebApp_2_4.DataAccess.Repositories;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using CoreWebApp_2_4.DataAccess.Data;
using System.Reflection;

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

            int CurrentPageNo = pageno;//10
            int PageSize = 3;

            int TotalItems = _dbcontext.Publishers.Count();
            int TotalPage = (int)Math.Ceiling((decimal)TotalItems / PageSize);//11

            if (CurrentPageNo > TotalPage)
                CurrentPageNo = 1;

            var data = _dbcontext.Publishers.Skip((CurrentPageNo-1)* PageSize).Take(PageSize).ToList();

           

           

            int startpage = CurrentPageNo - 5; //5
            int endpage = CurrentPageNo + 4; //11

            if(startpage <= 0)
            {
                endpage = endpage - (startpage - 1);
                startpage = 1;
            }
            if(endpage > TotalPage)
            {
                endpage = TotalPage;

                if((endpage - startpage) < 9)
                {
                    startpage = endpage - 9;
                }
            }

            if (data != null)
            {
                if(data.Count > 0)
                {
                    models = data.Select(x => PublisherModel.Convert(x)).ToList();
                }
            }

            PaginationModel pagination = new PaginationModel()
            {
                CurrentPage = CurrentPageNo,
                TotalPage = TotalPage,
                EndPage = endpage,
                StartPage = startpage
            };
            //if(TempData["Message"] != null)
            //{
            //    ViewBag.Message = TempData["Message"];
            //}

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
    }
}
