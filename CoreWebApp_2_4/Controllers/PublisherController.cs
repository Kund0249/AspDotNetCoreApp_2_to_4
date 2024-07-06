using Microsoft.AspNetCore.Mvc;
using CoreWebApp_2_4.Models;
using CoreWebApp_2_4.DataAccess.Repositories;
using System.Linq;

namespace CoreWebApp_2_4.Controllers
{
    public class PublisherController : Controller
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
            _publisherRepository.Save(PublisherModel.Convert(model));
            return RedirectToAction(nameof(Index));
        }
    }
}
