using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalFeedingCalculator.Business;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Data.Models;
using AnimalFeedingCalculator.UI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalFeedingCalculator.UI.Controllers
{
    public class FoodConsumptionController : Controller
    {
        private readonly IFoodConsumptionCalculationManager foodConsumptionCalculationManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FoodConsumptionController(IFoodConsumptionCalculationManager foodConsumptionCalculationManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.foodConsumptionCalculationManager = foodConsumptionCalculationManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Calculate()
        {
            var zooAnimalsFromSession = httpContextAccessor.HttpContext.Session.Get<IEnumerable<ZooAnimal>>("AllZooAnimalsUploaded");
            var priceDetailsFromSession = httpContextAccessor.HttpContext.Session.Get<IDictionary<string, string>>("PriceDictionary");
            var feedingRateDetailsFromSession = httpContextAccessor.HttpContext.Session.Get<IEnumerable<AnimalFeedingRate>>("AnimalFeedingRates");

            if (zooAnimalsFromSession == null || priceDetailsFromSession == null || feedingRateDetailsFromSession == null)
            {
                return View(null);
            }

            var inputParameters = new ZooFoodConsumptionInputParameters
            {
                ZooAnimals = zooAnimalsFromSession,
                AnimalFeedingRates = feedingRateDetailsFromSession,
                FoodPricingDetails = priceDetailsFromSession
            };

            var foodConsumptionDetails = await foodConsumptionCalculationManager.CalculateFoodConsumption(inputParameters);

            return View(foodConsumptionDetails);
        }
    }
}