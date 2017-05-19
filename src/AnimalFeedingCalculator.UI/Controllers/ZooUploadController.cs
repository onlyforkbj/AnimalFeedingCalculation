using System.Collections.Generic;
using System.Xml.Linq;
using AnimalFeedingCalculator.Data.Models;
using AnimalFeedingCalculator.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AnimalFeedingCalculator.UI.Controllers
{
    public class ZooUploadController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ZooUploadController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult Upload(ICollection<IFormFile> files)
        {
            IEnumerable<ZooAnimal> allZooAnimalsUploaded = null;
            foreach (var file in files)
            {
                var zooJson = JsonConvert.SerializeObject(XDocument.Load(file.FileName));
                var zooAnimalsUploaded = JsonConvert.DeserializeObject<ZooRoot>(zooJson);

                allZooAnimalsUploaded = zooAnimalsUploaded.Zoo.AllZooAnimals();

                httpContextAccessor.HttpContext.Session.Set("AllZooAnimalsUploaded", allZooAnimalsUploaded);
            }

            return View(allZooAnimalsUploaded);
        }
    }
}