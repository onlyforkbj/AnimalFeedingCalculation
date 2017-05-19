using System.Collections.Generic;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Business.Extensions;
using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.Data.Models;

namespace AnimalFeedingCalculator.Business
{
    public class Omnivores
    {
        public decimal CalculatePrice(ZooAnimal animal, FoodPriceCalculationParameters parameters,
                                     IDictionary<string, string> pricingDictionary)
        {
            if (animal.AnimalType != AnimalType.Omnivores)
            {
                return decimal.Zero;
            }
            var applicableMeat = animal.Kg * parameters.MeatPercentage.TrimEnd('%').ToDecimal() / 100;
            var applicableFruit = animal.Kg * (1 - parameters.MeatPercentage.TrimEnd('%').ToDecimal() / 100);

            var meatPrice = applicableMeat * parameters.Rate * pricingDictionary[FoodHabit.Meat.ToString()].ToDecimal();

            var fruitPrice = applicableFruit * parameters.Rate * pricingDictionary[FoodHabit.Fruit.ToString()].ToDecimal();

            return meatPrice + fruitPrice;
        }
    }
}