using System;
using System.Collections.Generic;
using System.Linq;
using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.Data.Models;
using AnimalFeedingCalculator.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalFeedingCalculator.UI.Controllers
{
    public class AnimalsUploadController : Controller
    {
        [HttpPost]
        public IActionResult Upload(ICollection<IFormFile> files)
        {
            IEnumerable<AnimalFeedingRate> animalFeedingRates = null;
            foreach (var file in files)
            {
                var animalRates = System.IO.File.ReadAllLines(file.FileName);

                var lines = animalRates.Select(price => price.Split(';'));

                animalFeedingRates = from line in lines
                                     select new AnimalFeedingRate
                                     {
                                         Animal = line[0],
                                         Rate = line[1],
                                         Food = (FoodHabit)Enum.Parse(typeof(FoodHabit), line[2]),
                                         MeatPercentage = line[3]
                                     };

                HttpContext.Session.Set("AnimalFeedingRates", animalFeedingRates);
            }
            return View(animalFeedingRates);
        }
    }
}