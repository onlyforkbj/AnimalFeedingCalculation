using AnimalFeedingCalculator.Data.Enums;
using AnimalFeedingCalculator.Data.Models;

namespace AnimalFeedingCalculator.UnitTests.Builders
{
    public class AnimalFeedingRateBuilder
    {
        private readonly AnimalFeedingRate animalFeedingRate = new AnimalFeedingRate
        {
            Food = FoodHabit.Both,
            Rate = "0.07",
            Animal = "Wolf",
            MeatPercentage = "90%"
        };

        private AnimalFeedingRateBuilder()
        {
        }

        public static AnimalFeedingRateBuilder Create()
        {
            return new AnimalFeedingRateBuilder();
        }

        public AnimalFeedingRateBuilder WithFood(FoodHabit food)
        {
            animalFeedingRate.Food = food;
            return this;
        }

        public AnimalFeedingRateBuilder WithRate(string rate)
        {
            animalFeedingRate.Rate = rate;
            return this;
        }

        public AnimalFeedingRateBuilder WithAnimal(string animal)
        {
            animalFeedingRate.Animal = animal;
            return this;
        }

        public AnimalFeedingRateBuilder WithMeatPercentage(string meatPercentage)
        {
            animalFeedingRate.MeatPercentage = meatPercentage;
            return this;
        }

        public AnimalFeedingRate Build()
        {
            return animalFeedingRate;
        }
    }
}