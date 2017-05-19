using System.Collections.Generic;
using System.Linq;
using AnimalFeedingCalculator.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalFeedingCalculator.UI.Controllers
{
    public class PriceUploadController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public PriceUploadController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult Upload(ICollection<IFormFile> files)
        {
            IDictionary<string, string> priceDictionary = null;
            foreach (var file in files)
            {
                var prices = System.IO.File.ReadAllLines(file.FileName);

                priceDictionary = prices
                                      .Select(price => price.Split('='))
                                      .ToDictionary(split => split[0], split => split[1]);

                httpContextAccessor.HttpContext.Session.Set("PriceDictionary", priceDictionary);
            }

            return View(priceDictionary);
        }
    }
}