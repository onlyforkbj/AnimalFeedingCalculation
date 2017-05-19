using System.Collections.Generic;
using AnimalFeedingCalculator.Business.Dtos;
using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.Data.Models;

namespace AnimalFeedingCalculator.UnitTests.Builders
{
    public class ZooFoodConsumptionInputParametersBuilder
    {
        private readonly ZooFoodConsumptionInputParameters zooParameters = new ZooFoodConsumptionInputParameters
        {
            ZooAnimals = new List<ZooAnimal>
            {
                AnimalBuilder.Create().WithAnimal("Lion").WithAnimalType(AnimalType.Carnivores).WithName("Mufasa").Build(),
                AnimalBuilder.Create().WithAnimal("Tiger").WithAnimalType(AnimalType.Carnivores).WithName("Asimov").Build(),
                AnimalBuilder.Create().WithAnimal("Giraffe").WithAnimalType(AnimalType.Herbivores).WithName("Susanna").Build(),
                AnimalBuilder.Create().WithAnimal("Wolf").WithAnimalType(AnimalType.Omnivores).WithName("Pin").Build()
            },
            FoodPricingDetails = new Dictionary<string, string>
            {
                {"Meat", "12.56"},
                {"Fruit", "5.6" }
            },
            AnimalFeedingRates = new List<AnimalFeedingRate>
            {
                AnimalFeedingRateBuilder.Create().Build(),
                AnimalFeedingRateBuilder.Create().WithAnimal("Lion").WithRate("0.10").WithFood(FoodHabit.Meat).Build(),
                AnimalFeedingRateBuilder.Create().WithAnimal("Tiger").WithRate("0.09").WithFood(FoodHabit.Meat).Build(),
                AnimalFeedingRateBuilder.Create().WithAnimal("Giraffe").WithRate("0.08").WithFood(FoodHabit.Fruit).Build(),
                AnimalFeedingRateBuilder.Create().WithAnimal("Zebra").WithRate("0.08").WithFood(FoodHabit.Fruit).Build(),
                AnimalFeedingRateBuilder.Create().WithAnimal("Piranha").WithRate("0.5")
                .WithFood(FoodHabit.Both).WithMeatPercentage("50%").Build()
            }
        };

        private ZooFoodConsumptionInputParametersBuilder()
        {
        }

        public static ZooFoodConsumptionInputParametersBuilder Create()
        {
            return new ZooFoodConsumptionInputParametersBuilder();
        }

        public ZooFoodConsumptionInputParameters Build()
        {
            return zooParameters;
        }
    }
}