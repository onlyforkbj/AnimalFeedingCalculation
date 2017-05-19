using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.Data.Models;

namespace AnimalFeedingCalculator.Business
{
    public class NonOmnivores
    {
        public decimal CalculatePrice(ZooAnimal animal,
            FoodPriceCalculationParameters parameters)
        {
            return animal.AnimalType == AnimalType.Omnivores ?
                decimal.Zero :
                animal.Kg * parameters.Rate * parameters.Price;
        }
    }
}