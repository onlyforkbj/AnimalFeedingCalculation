using System.Collections.Generic;
using AnimalFeedingCalculator.Data.Models;

namespace AnimalFeedingCalculator.Business.Dtos
{
    public class ZooFoodConsumptionInputParameters
    {
        public IEnumerable<ZooAnimal> ZooAnimals { get; set; }
        public IDictionary<string, string> FoodPricingDetails { get; set; }
        public IEnumerable<AnimalFeedingRate> AnimalFeedingRates { get; set; }
    }
}