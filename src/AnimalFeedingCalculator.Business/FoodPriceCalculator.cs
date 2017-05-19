using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Business.Extensions;
using AnimalFeedingCalculator.Business.ViewModels;
using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.Data.Models;

namespace AnimalFeedingCalculator.Business
{
    public class FoodPriceCalculator : IFoodPriceCalculator
    {
        private readonly Omnivores omnivores;
        private readonly NonOmnivores nonOmnivores;

        public FoodPriceCalculator(Omnivores omnivores, NonOmnivores nonOmnivores)
        {
            this.omnivores = omnivores;
            this.nonOmnivores = nonOmnivores;
        }

        public async Task<IList<AnimalFoodConsumption>> CalculatePriceAsync(ZooFoodConsumptionInputParameters inputParameters)
        {
            var resultFoodConsumptionDetails = (from animal in inputParameters.ZooAnimals
                                                let foodHabitDetails = DetermineFoodHabitDetails(animal,
                                                                                            inputParameters.AnimalFeedingRates,
                                                                                            inputParameters.FoodPricingDetails)
                                                select new AnimalFoodConsumption
                                                {
                                                    AnimalTypeName = animal.Animal,
                                                    Name = animal.Name,
                                                    AnimalType = animal.AnimalType,
                                                    FoodType = foodHabitDetails.Habit,
                                                    FoodCostPerKg = foodHabitDetails.Price,
                                                    FoodRatio = foodHabitDetails.Rate,
                                                    WeightInKgs = animal.Kg,
                                                    MeatConsumptionPercentage = foodHabitDetails.MeatPercentage,
                                                    PricePerDayFoodConsumption =
                                                    CalculatePerDayFoodCost(animal, foodHabitDetails, inputParameters.FoodPricingDetails)
                                                }).ToList();

            return await Task.FromResult(resultFoodConsumptionDetails);
        }

        private decimal CalculatePerDayFoodCost(ZooAnimal animal, FoodPriceCalculationParameters foodHabitDetails,
            IDictionary<string, string> pricingDictionary)
        {
            return animal.AnimalType == AnimalType.Omnivores
                ? omnivores.CalculatePrice(animal, foodHabitDetails, pricingDictionary)
                : nonOmnivores.CalculatePrice(animal, foodHabitDetails);
        }

        private static FoodPriceCalculationParameters DetermineFoodHabitDetails(ZooAnimal animal,
                                                                                IEnumerable<AnimalFeedingRate> feeingRates,
                                                                                IDictionary<string, string> priceDictionary)
        {
            var animalDetail = feeingRates.SingleOrDefault(rate => rate.Animal == animal.Animal);

            return new FoodPriceCalculationParameters
            {
                Habit = animalDetail.Food,
                Rate = animalDetail.Rate.ToDecimal(),
                Price = animalDetail.Food == FoodHabit.Both ?
                                            decimal.Zero :
                                            priceDictionary[animalDetail.Food.ToString()].ToDecimal(),
                MeatPercentage = HandleMeatConsumptionPercentage(animalDetail)
            };
        }

        private static string HandleMeatConsumptionPercentage(AnimalFeedingRate feedingDetails)
        {
            switch (feedingDetails.Food)
            {
                case FoodHabit.Meat:
                    return $"{100}%";

                case FoodHabit.Fruit:
                    return $"{0}%";

                case FoodHabit.Both:
                    return feedingDetails.MeatPercentage;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}